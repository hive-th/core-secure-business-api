using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.DotNet.AggregatesModel.ResourceAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.ResourceAggregate;

public class ResourcesBankResponse : ResourceValue
{
    public string SwiftCode { get; set; }
    public Image Logo { get; set; }
}