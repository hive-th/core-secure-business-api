using System.Net.Http.Headers;

namespace Core.Secure.Business.Domain.Utilities;

public static class BasicAuthorizationHelper
{
    public static AuthenticationHeaderValue CreateBasicAuthenticationHeaderValue(string userName, string password)
    {
        var authBytes = System.Text.Encoding.UTF8.GetBytes($"{userName}:{password}");

        var encodedBase64String = Convert.ToBase64String(authBytes);

        var result = new AuthenticationHeaderValue("Basic", encodedBase64String);

        return result;
    }
}