namespace Core.Secure.Business.Domain.AggregatesModel.OrderAggregate.Interface;

public interface ISuborder
{
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
}