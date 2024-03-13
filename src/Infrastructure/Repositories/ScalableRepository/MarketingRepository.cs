using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate.Interface;

namespace Core.Secure.Business.Infrastructure.Repositories.ScalableRepository;

public class MarketingRepository : IMarketingRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MarketingRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }
}