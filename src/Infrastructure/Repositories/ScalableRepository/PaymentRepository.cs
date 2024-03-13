using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate.Interface;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Infrastructure.Repositories.ScalableRepository;

public class PaymentRepository  : IPaymentRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PaymentRepository(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }
}