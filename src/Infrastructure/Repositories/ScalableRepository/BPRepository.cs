using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate.Interface;
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
}