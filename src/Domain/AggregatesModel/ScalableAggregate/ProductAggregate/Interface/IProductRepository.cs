namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate.Interface;

public interface IProductRepository
{
    Task<ProductResponse> GetProductByIdAsync(Guid ProductId);
    Task<UnitResponse> GetUnitByIdAsync(Guid UnitId);
}