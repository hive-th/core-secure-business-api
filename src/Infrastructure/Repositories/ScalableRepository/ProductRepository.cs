using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate.Interface;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Infrastructure.Repositories.ScalableRepository;

public class ProductRepository : IProductRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductRepository(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }
}