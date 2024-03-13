using Core.DotNet.Domain.Services;
using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.AuthAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate.Interface;
using Core.Secure.Business.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Domain.Services;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICacheService _cacheService;
    private readonly IAuthRepository _authRepository;
    private readonly IBPRepository _bpRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderRequestRepository _orderRequestRepository;
    private readonly IOrderService _orderService;
    
    public CartService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        ICacheService cacheService,
        IAuthRepository authRepository,
        IBPRepository bpRepository,
        ICartRepository cartRepository,
        IOrderRepository orderRepository,
        IOrderRequestRepository orderRequestRepository,
        IOrderService orderService
   )
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        _bpRepository = bpRepository ?? throw new ArgumentNullException(nameof(bpRepository));
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderRequestRepository = orderRequestRepository ?? throw new ArgumentNullException(nameof(orderRequestRepository));
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public Task<CreateCartResponse> CreateCartAsync(CreateCartRequest createCartRequest)
    {
        throw new NotImplementedException();
    }
}