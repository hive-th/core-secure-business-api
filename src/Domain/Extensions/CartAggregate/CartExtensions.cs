using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

namespace Core.Secure.Business.Domain.Extensions.CartAggregate;

public static class CartExtensions
{
    public static CartResponse ToCartResponse(this Cart cart)
    {
        var result = new CartResponse
        {
            Id = cart.Id,
            Dealers = cart.Dealers,
            Promotion = cart.Promotions,
            Summary = cart.Summary
        };

        return result;
    }
}