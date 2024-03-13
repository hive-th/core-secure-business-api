using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

namespace Core.Secure.Business.Domain.Services.Interface;

public interface ICartService
{
    Task<CreateCartResponse> CreateCartAsync(CreateCartRequest createCartRequest);
    //Task<CreateResponse> AddItemAsync(Guid cartId, AddItemRequest addItemRequest);
    //Task<CartPlaceOrderResponse> PlaceOrderAsync(Guid cartId);
    //Task<CartResponse> GetCartAsync(Guid cartId);
}