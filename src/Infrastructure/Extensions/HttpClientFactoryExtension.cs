using System.Diagnostics.CodeAnalysis;
using Core.Secure.Business.Infrastructure.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Secure.Business.Infrastructure.Extensions;

[ExcludeFromCodeCoverage]
public static class HttpClientFactoryExtension
{
    private const string BPApiClient = "BP_API";
    private const string ProductApiClient = "PRODUCT_API";
    private const string NotificationApiClient = "NOTIFICATION_API";
    private const string ResourcesApiClient = "RESOURCES_API";
    
    public static HttpClient CreateBPApiClient(this IHttpClientFactory httpClientFactory) => httpClientFactory.CreateClient(BPApiClient);
    public static HttpClient CreateProductApiClient(this IHttpClientFactory httpClientFactory) => httpClientFactory.CreateClient(ProductApiClient);
    public static HttpClient CreateNotificationClient(this IHttpClientFactory httpClientFactory) => httpClientFactory.CreateClient(NotificationApiClient);
    public static HttpClient CreateResourcesApiClient(this IHttpClientFactory httpClientFactory) => httpClientFactory.CreateClient(ResourcesApiClient);
  
    public static IServiceCollection AddCustomHttpClients(this IServiceCollection services, EnvironmentOptions options)
    {
        services.AddHttpClient(BPApiClient, c => { c.BaseAddress = new Uri(options.BP_API_ENDPOINT); });
        services.AddHttpClient(ProductApiClient, c => { c.BaseAddress = new Uri(options.PRODUCT_API_ENDPOINT); });
        services.AddHttpClient(NotificationApiClient, c => { c.BaseAddress = new Uri(options.NOTIFICATION_ENDPOINT); });
        services.AddHttpClient(ResourcesApiClient, c => { c.BaseAddress = new Uri(options.RESOURCE_API_ENDPOINT); });
       
        return services;
    }
}