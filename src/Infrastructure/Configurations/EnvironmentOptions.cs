using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Core.Secure.Business.Infrastructure.Configurations;

[ExcludeFromCodeCoverage]
public class EnvironmentOptions
{
    [Required] public string ASPNETCORE_ENVIRONMENT { get; init; }
    [Required] public string API_KEYS { get; init; }
    [Required] public string BASIC_AUTHENTICATION_USERNAME { get; init; }
    [Required] public string BASIC_AUTHENTICATION_PASSWORD { get; init; } 
    [Required] public string BP_API_ENDPOINT { get; init; }
    [Required] public string BP_BASIC_AUTHENTICATION_USERNAME { get; init; }
    [Required] public string BP_BASIC_AUTHENTICATION_PASSWORD { get; init; }
    
    [Required] public string PRODUCT_API_ENDPOINT { get; init; }
    [Required] public string PRODUCT_BASIC_AUTHENTICATION_USERNAME { get; init; }
    [Required] public string PRODUCT_BASIC_AUTHENTICATION_PASSWORD { get; init; }
    [Required] public string POSTGRES_CONNECTIONSTRING { get; init; }
    [Required] public string AUTH_JWKS_ENDPOINT { get; init; }
    [Required] public string AUTH_API_ENDPOINT { get; init; }
    [Required] public string AUTH_BASIC_AUTHENTICATION_USERNAME { get; init; }
    [Required] public string AUTH_BASIC_AUTHENTICATION_PASSWORD { get; init; }
    [Required] public string REDIS_CONNECTIONSTRING { get; init; }
    [Required] public string NOTIFICATION_ENDPOINT { get; init; }
    [Required] public string RESOURCE_API_ENDPOINT { get; init; }
    [Required] public string? AMQP_HOST { get; set; }
    [Required] public string? AMQP_PORT { get; set; }
    [Required] public string? AMQP_USERNAME { get; set; }
    [Required] public string? AMQP_PASSWORD { get; set; }
    [Required] public string? AMQP_SYNC_DELETE_ACCOUNT_EXCHANGE_KEY { get; set; }
    [Required] public string HASH_SECRET_KEY { get; init; }
    [Required] public string HASH_SECRET_IV { get; init; }
}