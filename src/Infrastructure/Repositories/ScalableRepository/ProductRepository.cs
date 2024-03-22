using Core.DotNet.Extensions.Utilities;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate.Interface;
using Core.Secure.Business.Infrastructure.Extensions;
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
    
    public async Task<ProductResponse> GetProductByIdAsync(Guid ProductId)
    {
        var client = _httpClientFactory.CreateProductApiClient();
        client.ForwardHeaders(_httpContextAccessor);

        var clientResult = await client.GetAsync($"product/{ProductId.ToString()}");
        var content = await clientResult.Content.ReadAsStringAsync();

        if (!clientResult.IsSuccessStatusCode)
            return null;

        return content.DeserializerObject<ProductResponse>();
    }
    
    public async Task<UnitResponse> GetUnitByIdAsync(Guid UnitId)
    {
        var client = _httpClientFactory.CreateProductApiClient();
        client.ForwardHeaders(_httpContextAccessor);

        var clientResult = await client.GetAsync($"console/unit/{UnitId.ToString()}");
        var content = await clientResult.Content.ReadAsStringAsync();

        if (!clientResult.IsSuccessStatusCode)
            return null;

        return content.DeserializerObject<UnitResponse>();
    }
}