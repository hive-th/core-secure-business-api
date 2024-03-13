using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.OrderAggregate;

public class SuborderItem
{
    public Guid ProductId { get; set; }
    public Locale Name { get; set; }
    public Locale Description { get; set; }
    public Guid DealerId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid MakerId { get; set; }
    public string Sku { get; set; }
    public string ToyoSku { get; set; }

    public Image Image { get; set; }
    public List<CartDetailProductBadge> Badges { get; set; }
    public ProductPackageUnitResponse PackageUnit { get; set; }
    public string PriceUnitDisplay { get; set; }
    public string SaleUnitDisplay { get; set; }
    public decimal Price { get; set; }
    public double? VatPercent { get; set; }
    public double Quantity { get; set; }
    public ProductWeight Weight { get; set; }
    public ProductDimensions Dimensions { get; set; }
    public decimal Amount { get; set; }
    public string PriceCurrencyDisplay { get; set; }
    public string Remark { get; set; }
    public DateTime CreatedAt { get; set; }
}