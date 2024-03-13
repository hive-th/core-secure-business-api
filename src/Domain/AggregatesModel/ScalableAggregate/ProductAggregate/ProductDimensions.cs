namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate;

public class ProductDimensions
{
    public double? Length { get; set; }
    public double? Width { get; set; }
    public double? Height { get; set; }
    public string Unit { get; set; }
}