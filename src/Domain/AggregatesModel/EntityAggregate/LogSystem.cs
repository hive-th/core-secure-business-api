using Core.DotNet.Domain.SeedWork;
using Core.Secure.Business.Domain.AggregatesModel.LoggingAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

public class LogSystem : BaseEntity
{
    public LogType Type { get; set; }
    public string ReferenceType { get; set; }
    public string ReferenceId { get; set; }
    public string Source { get; set; }
    public string Description { get; set; }
    public LogObjectType ObjectType { get; set; }
    public string ObjectValue { get; set; }
}