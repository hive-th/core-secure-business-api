using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

public class CartDetail
{
    //public ShippingLocation ShippingLocation { get; set; }
    //public TaxLocation TaxLocation { get; set; }
    //public Payment Payment { get; set; }
    //public List<CartDetailMall> Malls { get; set; } = new();
   // public CartDetailPromotion Promotion { get; set; }
    // public decimal MinTotalAmount => Malls.Sum(m => m.MinTotalAmount);
    // public decimal MaxTotalAmount => Malls.Sum(m => m.MaxTotalAmount);
    // public decimal TotalMinAmountExcludeVat { get; set; }
    // public decimal TotalMaxAmountExcludeVat { get; set; }
    // public double? VatPercent { get; set; }
    // public decimal TotalShippingFee => Malls
    //     .SelectMany(m => m.Stores)
    //     .SelectMany(m => m.Subcarts)
    //     .Sum(m => m.Shipping?.TotalFee ?? 0);
    //
    // public decimal TotalShippingDiscount => Promotion is null ? 0 : Promotion.DiscountItems
    //     .Sum(m => m.OrdersDiscount
    //         .Sum(n => n.ShippingDiscountPrice));
    //
    // public decimal TotalItemsDiscount => Promotion is null ? 0 : Promotion.DiscountItems
    //     .Sum(m => m.OrdersDiscount
    //         .Sum(n => n.ProductDiscountPrice));
    //
    // public decimal TotalDiscount => Promotion is null ? 0 : Promotion.DiscountItems.Sum(m => m.SummaryDiscount);
    // public decimal MinGrandTotal => MinTotalAmount - (TotalDiscount > MinTotalAmount ? MinTotalAmount : TotalDiscount);
    // public decimal MaxGrandTotal => MaxTotalAmount - (TotalDiscount > MaxTotalAmount ? MaxTotalAmount : TotalDiscount);
}

public class CartDetailMall
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Image Logo { get; set; }
    public List<CartDetailStore> Stores { get; set; } = new();
    // public decimal MinTotalAmount => Stores.Sum(m => m.MinTotalAmount);
    // public decimal MaxTotalAmount => Stores.Sum(m => m.MaxTotalAmount);
    // public DateTime UpdatedAt => Stores.Max(m => m.UpdatedAt);
}

public class CartDetailStore
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Image Logo { get; set; }
    public List<CartDetailSubcart> Subcarts { get; set; } = new();
    // public decimal MinTotalAmount => Subcarts.Sum(m => m.MinTotalAmount);
    // public decimal MaxTotalAmount => Subcarts.Sum(m => m.MaxTotalAmount);
    // public Location Location { get; set; }
    // public Location WarehouseLocation { get; set; }
    // public bool IsActive { get; set; }
    // public DateTime UpdatedAt => Subcarts.Max(m => m.UpdatedAt);
}

public class CartDetailSubcart
{
    public Guid Id { get; set; }
    //public CargoTemperature CargoTemperature { get; set; }
    public List<CartDetailItem> Items { get; set; } = new();
    //public ShippingDetail Shipping { get; set; }
    // public decimal MinTotalItemsAmount => Items.Where(n => n.IsSelected).Sum(m => m.MinTotalAmount);
    // public decimal MaxTotalItemsAmount => Items.Where(n => n.IsSelected).Sum(m => m.MaxTotalAmount);
    // public decimal MinTotalAmount => MinTotalItemsAmount + (Shipping?.TotalFee ?? 0);
    // public decimal MaxTotalAmount => MaxTotalItemsAmount + (Shipping?.TotalFee ?? 0);
    // public DateTime UpdatedAt => Items.Max(m => m.CreatedAt);
}

public class CartDetailItem
{
    public string ProductId { get; set; }
    public string StoreSku { get; set; }
    public string HiveSku { get; set; }
    public bool IsSelected { get; set; }
    public string Name { get; set; }
    public string CategoryId { get; set; }
    public Image Image { get; set; }
    public List<CartDetailProductBadge> Badges { get; set; }
    public CartDetailSaleUnit SaleUnit { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public double? VatPercent { get; set; }
    public double Quantity { get; set; }
   // public ProductWeight Weight { get; set; }
    //public ProductDimensions Dimensions { get; set; }
    public decimal MinTotalAmount => MinPrice * (decimal)Quantity;
    public decimal MaxTotalAmount => MaxPrice * (decimal)Quantity;
    public string PriceCurrencyDisplay { get; set; }
    public string Remark { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CartDetailProductBadge
{
    public string Type { get; set; }
    public string Name { get; set; }
}

public class CartDetailSaleUnit : Unit
{
    public string Type { get; set; }
    public double? MinVolumn { get; set; }
    public double? MaxVolumn { get; set; }
    public CartDetailVolumeUnit VolumeUnit { get; set; }
    public CartDetailTradeUnit TradeUnit { get; set; }
}

public class CartDetailVolumeUnit : Unit
{

}

public class CartDetailTradeUnit : Unit
{

}
