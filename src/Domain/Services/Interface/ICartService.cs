using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

namespace Core.Secure.Business.Domain.Services.Interface;

public interface ICartService
{
    Task<CreateCartResponse> CreateCartAsync(CreateCartRequest request);
    Task<CartResponse> GetCartAsync(Guid cartId);
    Task<CartResponse> MappingGuestUserAsync(string guestId);
    Task<List<CartValidationResponse>> ValidateCartOnPlaceOrderAsync(Guid cartId);
}