using System.Text;
using Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate.Interface;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;
using RabbitMQ.Client;

namespace Core.Secure.Business.Infrastructure.Repositories.ProviderRepository;

public class AmqpRepository : IAmqpRepository
{
    private readonly string _exchangeKey;
    private readonly IOfflineContext _offlineContext;
    private readonly IRabbitMQContext _rabbitMQContext;
    private readonly Logger _logger;

    public AmqpRepository(string exchangeKey, IOfflineContext offlineContext, IRabbitMQContext connection)
    {
        _exchangeKey = exchangeKey ?? throw new ArgumentNullException(nameof(exchangeKey));
        _offlineContext = offlineContext ?? throw new ArgumentNullException(nameof(offlineContext));
        _rabbitMQContext = connection ?? throw new ArgumentNullException(nameof(connection));

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
    }

    public void PublishMessage(string message)
    {
        IModel channel = null;

        try
        {
            channel = _rabbitMQContext.GetConnection().CreateModel();
            channel.BasicPublish(exchange: _exchangeKey,
                routingKey: "",
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(message));
            channel.ConfirmSelect();

            // _logger.Information("Publish Message to AMQP : {message}", message);
        }
        catch (Exception e)
        {
            _offlineContext.AddOfflineQueues(new OfflineQueueDetail
            {
                Id = Guid.NewGuid(),
                Message = message,
                TryTimes = 1
            });

            _logger.Error("Error Publish Message to AMQP : {e}", e);
        }
        finally
        {
            if (channel is { IsOpen: true })
                channel.Close();
        }
    }
}