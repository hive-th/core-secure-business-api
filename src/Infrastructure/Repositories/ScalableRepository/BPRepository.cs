using Core.DotNet.Extensions.Utilities;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate.Interface;
using Core.Secure.Business.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.Secure.Business.Infrastructure.Repositories.ScalableRepository;

public class BPRepository : IBPRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDistributedCache _distributedCache;

    public BPRepository(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IDistributedCache distributedCache)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
    }
    
    public async Task<VendorDetailResponse> GetVendorByIdAsync(Guid vendorId)
    {
        var client = _httpClientFactory.CreateBPApiClient();
        client.ForwardHeaders(_httpContextAccessor);

        var clientResult = await client.GetAsync($"vendor/{vendorId.ToString()}");
        var content = await clientResult.Content.ReadAsStringAsync();

        if (!clientResult.IsSuccessStatusCode)
            return null;

        return content.DeserializerObject<VendorDetailResponse>();
    }

    public async Task<CustomerVendorResponse> GetCustomerVendorByAccountAsync(Guid vendorId)
    {
        var client = _httpClientFactory.CreateBPApiClient();
        client.ForwardHeaders(_httpContextAccessor);

        var clientResult = await client.GetAsync($"client/customer-vendor/{vendorId.ToString()}");
        var content = await clientResult.Content.ReadAsStringAsync();

        if (!clientResult.IsSuccessStatusCode)
            return null;

        return content.DeserializerObject<CustomerVendorResponse>();
    }
}