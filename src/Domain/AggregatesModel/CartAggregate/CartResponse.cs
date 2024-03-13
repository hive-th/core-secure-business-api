namespace Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

public class CartResponse
{
    public Guid Id { get; set; }
}

public class ProductPackageUnitResponse
{
    public string QuantityDisplay { get; set; }
    public string UnitDisplay { get; set; }
}