namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.MarketingAggregate;

public class CartDetailPromotion
{
    public Guid Id { get; set; }
    public List<CartPromotionDiscount> DiscountItems { get; set; } = new();
}

public class CartPromotionResponse : CartDetailPromotion
{

}

public class CartPromotionDiscount
{
    public string ReferenceId { get; set; }
    public decimal SummaryDiscount { get; set; }
    public List<CartPromotionSubcartDiscountResponse> OrdersDiscount { get; set; }
}

public class CartPromotionSubcartDiscountResponse
{
    public string OrderShipmentId { get; set; }
    public string TemperatureType { get; set; }
    public CartPromotionStore Store { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal ProductDiscountPrice { get; set; }
    public decimal ShippingDiscountPrice { get; set; }
    public CartPromotionComputeDescription ComputeDescription { get; set; }
}

public class CartPromotionComputeDescription
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string PromotionName { get; set; }
    public string DisplayDescription { get; set; }
    public bool IsFullyRedeemed { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid RuleId { get; set; }
    public string RuleType { get; set; }
    public int? Priority { get; set; }
    public DateTime PromotionCreatedAt { get; set; }
}