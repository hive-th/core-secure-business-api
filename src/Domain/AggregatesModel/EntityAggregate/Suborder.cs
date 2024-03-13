using Core.DotNet.Domain.SeedWork;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

public class Suborder : BaseEntity, ISoftDelete, ISuborder
{
    public Guid OrderId { get; set; }
    public string SuborderNo { get; set; }
    public SuborderType SuborderType { get; set; }
    public ShippingType ShippingType { get; set; }
    public OrderStatus Status { get; set; }
    public CartDetailPromotion Promotion { get; set; }
    public CartPromotionSubcartDiscountResponse SuborderDiscount { get; set; }
    public List<SuborderItem> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal? TotalAmountExceptVat { get; set; }
    public decimal? TotalAmountExceptVatDiscounted { get; set; }
    public decimal? TotalAmountIncludeVat { get; set; }
    public decimal? TotalAmountIncludeVatDiscounted { get; set; }
    public decimal? TotalAmountExcludeVat { get; set; }
    public decimal? TotalAmountExcludeVatDiscounted { get; set; }
    public decimal? TotalAmountVat { get; set; }
    public decimal? TotalAmountVatDiscounted { get; set; }
    public decimal? TotalShippingFee { get; set; }
    public decimal? TotalShippingFeeExcludeVat { get; set; }
    public decimal? TotalShippingFeeVat { get; set; }
    public decimal? TotalShippingDiscount { get; set; }
    public decimal TotalVat { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalItemsDiscount { get; set; }
    public decimal GrandTotal { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    
    public ICollection<OrderDocument> OrderDocuments { get; set; }
    public Order Orders { get; set; }
}