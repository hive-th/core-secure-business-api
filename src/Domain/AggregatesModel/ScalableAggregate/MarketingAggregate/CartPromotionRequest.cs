using Core.DotNet.AggregatesModel.LocationAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate;

public class CartPromotionRequest
{
    public string ReferenceId { get; set; }
    public Customer Customer { get; set; }
    public List<CartPromotionSubcart> CalculationItems { get; set; } = new();
}

public class Customer
{
    public string Id { get; set; }
}

public class CartPromotionSubcart
{
    public CartPromotionMall Mall { get; set; }
    public CartPromotionStore Store { get; set; }
    public string Status { get; set; }
    public string OrderShipmentId { get; set; }
    public string OrderPurchaseId { get; set; }
    public decimal TotalMinPriceCheckout { get; set; }
    public decimal TotalMaxPriceCheckout { get; set; }
    public string TemperatureType { get; set; }
    public decimal ProviderPrice { get; set; }
    public string ProviderName { get; set; }
    public List<CartPromotionItem> ProductItems { get; set; } = new();
    public double? Distance { get; set; }
    public Location ShipFrom { get; set; }
    public Location ShipTo { get; set; }
}

public class CartPromotionMall
{
    public string Id { get; set; }
}

public class CartPromotionStore
{
    public string Id { get; set; }
}

public class CartPromotionItem
{
    public string Sku { get; set; }
    public string HiveSku { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Amount { get; set; }
}
