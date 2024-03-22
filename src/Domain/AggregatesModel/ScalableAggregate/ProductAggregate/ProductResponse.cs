using Core.DotNet.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate;

public class ProductResponse
{
    public string Id { get; set; }
    public Locale Name { get; set; }
    public Locale Description { get; set; }
    public string DealerId { get; set; }
    public string CategoryId { get; set; }
    public string MakerId { get; set; }
    public List<Image> Image { get; set; } = new();
    public List<Image> Image3D { get; set; } = new();
    public List<Image> Drawing { get; set; } = new();
    public List<Image> Catalog { get; set; } = new();
    public List<string> ComplementaryProductId { get; set; } = new();
    public List<string> SimilarProductId { get; set; } = new();
    public List<string> PartProductId { get; set; } = new();
    public decimal? Rating { get; set; }
    public string Sku { get; set; }
    public string ToyoSku { get; set; }
    public string PreOrderMode { get; set; }
    public int PreOrderDay { get; set; }
    public int Sold { get; set; }
    public decimal Cost { get; set; }
    public decimal InStock { get; set; }
    public bool IsStockProduct { get; set; }
    public decimal? Width { get; set; }
    public decimal? Height { get; set; }
    public decimal? Depth { get; set; }
    public decimal? Weight { get; set; }
    public string Shipment { get; set; }
    public string ProductStatus { get; set; }
    public bool IsGlobal { get; set; }
    public bool IsActive { get; set; }
    public int AveragePreparation { get; set; }
    public List<ProductPriceUnitResponse> ProductPriceUnit { get; set; }
    public List<CategoryProductAttributeValueResponse> CategoryProductAttributeValue { get; set; }
}

public class ProductPriceUnitResponse
{
    public string Id { get; set; }
    public UnitResponse Unit { get; set; }
    public bool HasVat { get; set; }
    public decimal VatValue { get; set; }
    public decimal Price { get; set; }
    public int Qty { get; set; }
    public bool IsActive { get; set; }
    public List<ProductPriceTierResponse> ProductPriceTier { get; set; }
}

public class ProductPriceTierResponse
{
    public string Id { get; set; }
    public string CustomerTierId { get; set; }
    public decimal PercentPrice { get; set; }
    public decimal Discount { get; set; }
    public bool IsActive { get; set; }
}

public class CategoryProductAttributeValueResponse
{
    public string CategoryId { get; set; }
    public string ProductId { get; set; }
    public string AttributeSetId { get; set; }
    public string AttributeId { get; set; }
    public string Value { get; set; }
    public Locale Description { get; set; }
    public List<Image> Image { get; set; }
    public bool IsActive { get; set; }
}