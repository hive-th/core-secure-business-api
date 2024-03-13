using System.Net.Http.Headers;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.AuthAggregate.Interface;
using Core.Secure.Business.Domain.Utilities;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Infrastructure.Repositories.ScalableRepository;

public class AuthRepository : IAuthRepository
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AuthenticationHeaderValue _basicAuthorizationHeader;
    
    public AuthRepository(IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory, string basicAuthUserName, string basicAuthPassword)
    {
        _contextAccessor = contextAccessor ?? throw new ArgumentException(nameof(HttpContextAccessor));
        _httpClientFactory = httpClientFactory ?? throw new ArgumentException(nameof(httpClientFactory));

        if (String.IsNullOrEmpty(basicAuthUserName) || String.IsNullOrEmpty(basicAuthPassword))
            throw new ArgumentNullException($"{nameof(basicAuthUserName)}/{nameof(basicAuthPassword)}");

        _basicAuthorizationHeader =
            BasicAuthorizationHelper.CreateBasicAuthenticationHeaderValue(basicAuthUserName, basicAuthPassword);
    }
}