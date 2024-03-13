using Core.DotNet.Domain.SeedWork;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.AuthAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

public class OrderRequest : BaseEntity, ISoftDelete
{
    public string OrderRequestNo { get; set; }
    public CartDetailPromotion Promotion { get; set; }
    public AuthAccount Buyer { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public ICollection<Order> Orders { get; set; }
}
