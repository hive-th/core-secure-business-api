using Core.DotNet.Domain.Services;
using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate.Interface;
using Core.Secure.Business.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Domain.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICacheService _cacheService;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderRequestRepository _orderRequestRepository;

    
    public OrderService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        ICacheService cacheService,
        IOrderRepository orderRepository,
        IOrderRequestRepository orderRequestRepository
    )
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderRequestRepository = orderRequestRepository ?? throw new ArgumentNullException(nameof(orderRequestRepository));
    }

}