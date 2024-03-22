using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Core.DotNet.Domain.Services;
using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.LoggingAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ProviderAggregate.RabbitMQAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate.Interface;
using Core.Secure.Business.Domain.Facades;
using Core.Secure.Business.Domain.Facades.Interface;
using Core.Secure.Business.Domain.Services;
using Core.Secure.Business.Domain.Services.Interface;
using Core.Secure.Business.Infrastructure.Configurations;
using Core.Secure.Business.Infrastructure.DbContexts;
using Core.Secure.Business.Infrastructure.Extensions;
using Core.Secure.Business.Infrastructure.Repositories;
using Core.Secure.Business.Infrastructure.Repositories.ProviderRepository;
using Core.Secure.Business.Infrastructure.Repositories.ScalableRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.Secure.Business.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, EnvironmentOptions options)
    {   
        services.AddCustomDbContext(options.POSTGRES_CONNECTIONSTRING);
        services.AddScoped<DbContext>(m => m.GetService<BusinessDbContext>());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddCustomHttpClients(options);
        services.AddSingleton<IOfflineContext, OfflineContext>();
        services.AddSingleton<IRabbitMQContext>(m =>
        {
            return new RabbitMQContext(options, m.GetService<IOfflineContext>());
        });

        #region Repositories
        
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ILogSystemRepository, LogSystemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderRequestRepository, OrderRequestRepository>();
        
        #endregion
        
        #region Repositories ProviderRepository
        
        services.AddScoped<IAmqpRepository>(m => new AmqpRepository(
            options.AMQP_SYNC_DELETE_ACCOUNT_EXCHANGE_KEY, 
            m.GetService<IOfflineContext>(), 
            m.GetService<IRabbitMQContext>()));
        
        #endregion
        
        #region Repositories ScalableRepository
        
        services.AddScoped<IBPRepository, BPRepository>();
        services.AddScoped<IMarketingRepository, MarketingRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        #endregion
        
        #region Facades

        services.AddTransient<IOrderFacade, OrderFacade>();

        #endregion

        #region Services
        
        services.AddTransient<ICacheService, CacheService>();
        services.AddTransient<ICartService, CartService>();
        services.AddTransient<ILoggingService, LoggingService>();
        services.AddTransient<IOrderService, OrderService>();
        
        #endregion

        return services;
    }

    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<BusinessDbContext>(options =>
        {
            options.UseNpgsql(connectionString,
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(BusinessDbContext).GetTypeInfo().Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromMinutes(10), null);
                });
        });

        return services;
    }
}