using Core.DotNet.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ProductAggregate;

public class UnitStandardResponse
{
    public Guid Id { get; set; }
    public string MeasureType { get; set; }
    public Locale Name { get; set; }
    public bool IsActive { get; set; }
}