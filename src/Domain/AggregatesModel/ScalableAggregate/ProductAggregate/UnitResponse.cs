using Core.DotNet.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate;

public class UnitResponse
{
    public Guid Id { get; set; }
    public Locale Name { get; set; }
    public string Symbol { get; set; }
    public UnitStandardResponse UnitStandard { get; set; }
}