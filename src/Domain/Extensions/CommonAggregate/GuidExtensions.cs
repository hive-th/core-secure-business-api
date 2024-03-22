using Microsoft.IdentityModel.Tokens;

namespace Core.Secure.Business.Domain.Extensions.CommonAggregate;

public static class GuidExtensions
{
    public static Guid ToGuidResponse(this string request)
    {
        var guid = new Guid();
        if (!request.IsNullOrEmpty())
        {
            guid = Guid.Parse(request);
        }
         
        return guid;
    }
}