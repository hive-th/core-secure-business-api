using System.Text;
using Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate.Interface;
using Core.Secure.Business.Infrastructure.Configurations;
using RabbitMQ.Client;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;

namespace Core.Secure.Business.Infrastructure.DbContexts;

public class RabbitMQContext : IRabbitMQContext
{
    private static IConnection _rabbitMqConnection;
    private static IOfflineContext _offlineContext;

    private static Logger _logger;

    public RabbitMQContext(EnvironmentOptions options, IOfflineContext offlineContext)
    {
        _offlineContext = offlineContext ?? throw new ArgumentNullException(nameof(offlineContext));

        var customThemeStyles =
            new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
            {
                {
                    ConsoleThemeStyle.LevelError, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Red,
                    }
                },
                {
                    ConsoleThemeStyle.LevelInformation, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Green,
                    }
                },
                {
                    ConsoleThemeStyle.String, new SystemConsoleThemeStyle
                    {
                        Foreground = ConsoleColor.Yellow,
                    }
                },
            };

        var customTheme = new SystemConsoleTheme(customThemeStyles);

        _logger = new LoggerConfiguration()
            .WriteTo.Console(theme: customTheme)
            .CreateLogger();

        try
        {
            var factory = new ConnectionFactory
            {
                HostName = options.AMQP_HOST,
                VirtualHost = "/",
                Port = options.AMQP_PORT is null ? 5672 : int.Parse(options.AMQP_PORT),
                UserName = options.AMQP_USERNAME,
                Password = options.AMQP_PASSWORD
            };

            _rabbitMqConnection = factory.CreateConnection();
            factory.AutomaticRecoveryEnabled = true;
            factory.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);
            factory.TopologyRecoveryEnabled  = true;

            _rabbitMqConnection.ConnectionShutdown += (sender, args) =>
            {
                _logger.Error("[AMQP] Connection Shutdown");

                Thread.Sleep(10000);

                while (_offlineContext.OfflineQueues.Count > 0)
                {
                    Thread.Sleep(5000);

                    var pendingLists = new HashSet<OfflineQueueDetail>(_offlineContext.OfflineQueues);
                    foreach (var pendingQueue in pendingLists)
                    {
                        try
                        {
                            var channel = _rabbitMqConnection.CreateModel();
                            channel.BasicPublish(exchange: options.AMQP_SYNC_DELETE_ACCOUNT_EXCHANGE_KEY,
                                routingKey: "",
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes(pendingQueue.Message));

                            _logger.Information("[AMQP] Retry Publish Success : {e}", pendingQueue.Message);

                            _offlineContext.RemoveOfflineQueues(pendingQueue.Id);
                        }
                        catch (Exception e)
                        {
                            _offlineContext.AddTryTimes(new OfflineQueueDetail
                            {
                                Id = pendingQueue.Id,
                                Message = pendingQueue.Message,
                                TryTimes = pendingQueue.TryTimes + 1
                            });

                            _logger.Error("Retry Publish Failed [{0}] : {1}", pendingQueue.TryTimes, pendingQueue.Message);
                            Console.WriteLine(e);
                        }
                    }
                }
            };

            // Console.WriteLine("[AMQP] Connection Successful");
        }
        catch (Exception err)
        {
            _logger.Error("[AMQP] Connection Failed");
            Console.WriteLine(err);
        }
    }

    public IConnection GetConnection() => _rabbitMqConnection;
}