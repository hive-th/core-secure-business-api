using Core.DotNet.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

public class CartResponse
{
    public Guid Id { get; set; }
    public List<Dealer> Dealers { get; set; }
    public List<Promotion> Promotion { get; set; }
    public Summary Summary { get; set; }
}

public class Dealer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsRegister { get; set; }
    public Image Logo { get; set; }
    public List<ProductItem> ProductItems { get; set; }
}

public class ProductItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Image Logo { get; set; }
    public ProductMaker Maker { get; set; }
    public string SKU { get; set; }
    public string PreOrderType { get; set; }
    public ProductUnit Unit { get; set; }
    public decimal UnitPrice { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
}

public class ProductMaker
{
    public string MakerId { get; set; }
    public string MakerName { get; set; }
}

public class Promotion
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class Summary
{
    public decimal SubTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Vat { get; set; }
    public int Items { get; set; }
    public decimal TotalAmount { get; set; }
}

public class ProductUnit
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class ProductPackageUnitResponse
{
    public string QuantityDisplay { get; set; }
    public string UnitDisplay { get; set; }
}