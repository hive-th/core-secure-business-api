using Core.Secure.Business.Domain.AggregatesModel.FacadesAggregate;
using Core.Secure.Business.Domain.Facades.Interface;
using Core.Secure.Business.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Domain.Facades;

public class OrderFacade : IOrderFacade
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICartService _cartService;
    private readonly ILoggingService _loggingService;

    public OrderFacade(IHttpContextAccessor httpContextAccessor, ICartService cartService)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }

    public Task<FacadesResponse> PlaceOrderAsync(Guid cartId)
    {
        throw new NotImplementedException();
    }
}