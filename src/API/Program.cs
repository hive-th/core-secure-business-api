using System.Reflection;
using Core.DotNet.AggregatesModel.AuthAggregate;
using Core.DotNet.AggregatesModel.ExceptionAggregate;
using Core.DotNet.Extensions.DependencyInjection;
using Core.DotNet.Extensions.Middlewares;
using Core.DotNet.Middlewares;
using Core.Secure.Business.API.Extensions;
using Core.Secure.Business.Infrastructure.Configurations;
using Core.Secure.Business.Infrastructure.DbContexts;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var allowOrigins = "*";
var builder = WebApplication.CreateBuilder(args);
var environmentOptions = builder.Services.AddCustomOptions<EnvironmentOptions>(builder.Configuration);

builder.Services.AddCustomConfigurations(environmentOptions);

builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowOrigins,
        builder =>
        {
            builder.WithOrigins(allowOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddCustomAppInsightsService(builder.Configuration, Assembly.GetExecutingAssembly().GetName().Version.ToString(3));

builder.Services.AddControllers()
    .AddResponseJsonOptions()
    .AddFluentValidation();

builder.Services.AddAuthentication(AuthenticationSchemes.JwtBearer)
    .AddScheme<JwtBearerAuthenticationOptions, JwtBearerAuthenticationHandler>(
        AuthenticationSchemes.JwtBearer,
        options =>
        {
            options.JWKsEndpoint = environmentOptions.AUTH_JWKS_ENDPOINT;
        })
    .AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>(
        AuthenticationSchemes.BasicAuth,
        options =>
        {
            options.Username = environmentOptions.BASIC_AUTHENTICATION_USERNAME;
            options.Password = environmentOptions.BASIC_AUTHENTICATION_PASSWORD;
        })
    .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(
        AuthenticationSchemes.ApiKey,
        options =>
        {
            options.ApiKeys = environmentOptions.API_KEYS;
        });

builder.Services.AddSingleton<IPostConfigureOptions<JwtBearerAuthenticationOptions>, JwtBearerAuthenticationPostConfigureOptions>();
builder.Services.AddSingleton<IPostConfigureOptions<BasicAuthenticationOptions>, BasicAuthenticationPostConfigureOptions>();
builder.Services.AddSingleton<IPostConfigureOptions<ApiKeyAuthenticationOptions>, ApiKeyAuthenticationPostConfigureOptions>();

builder.Services.AddMemoryCache();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = environmentOptions.REDIS_CONNECTIONSTRING;
});

builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new OpenApiInfo { Title = "Core Secure Business API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseHsts();

app.UpdateDatabase<BusinessDbContext>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandling(new ErrorHandlingOptions("core.secure.business"));

app.UseRequestCulture();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(allowOrigins);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()).AllowAnonymous();
    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = _ => false }).AllowAnonymous();
});

app.Run();