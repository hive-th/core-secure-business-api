using Core.DotNet.Domain.SeedWork;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

public class Order : BaseEntity, ISoftDelete
{
    public Guid OrderRequestId { get; set; }
    public string OrderNo { get; set; }
    public OrderStatus Status { get; set; }
    public ShippingLocation ShippingLocation { get; set; }
    public TaxLocation TaxLocation { get; set; }
    public Payment Payment { get; set; }
    public PaymentChargeResponse PaymentCharge { get; set; }
    public string PaymentChargeNo { get; set; }
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
    public ICollection<Suborder> Suborders { get; set; }
    // public ICollection<GoodsReceipt> GoodsReceipts { get; set; }
    
    public OrderRequest OrderRequests { get; set; }
}