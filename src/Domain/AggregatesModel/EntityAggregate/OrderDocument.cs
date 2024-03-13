using Core.DotNet.Domain.SeedWork;
using Core.Secure.Business.Domain.AggregatesModel.DocumentAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

public class OrderDocument : BaseEntity, ISoftDelete
{
    public Guid OrderId { get; set; }
    public Guid SuborderId { get; set; }
    public DocumentType DocumentType { get; set; }
    public string DocumentNo { get; set; }
    public DocumentType RefDocumentType { get; set; }
    public string RefDocumentNo { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    
    public Order Orders { get; set; }
    public Suborder Suborders { get; set; }
}
