using Core.DotNet.Domain.SeedWork;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

public class Cart : BaseEntity, ISoftDelete
{
    public CartType CartType { get; set; }
    public CartDetail Detail { get; set; }
    public string Description { get; set; }
    public string GuestId { get; set; }
    public Guid BuyerId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}