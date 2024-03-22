using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.DotNet.AggregatesModel.LocationAggregate;
using Core.DotNet.AggregatesModel.ResourceAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate;


public class VendorResponse
{
    public Guid Id { get; set; }
    public Locale Name { get; set; }
}

public class VendorDetailResponse : VendorResponse
{
    public string ReferenceId { get; set; }
    public string VendorType { get; set; } 
    public string BusinessType { get; set; }
    public Locale Description { get; set; }
    public List<PhoneRequest> PhoneNumber { get; set; }
    public List<string> Email { get; set; }
    public string TaxId { get; set; }
    public string CardId { get; set; }
    public decimal? VatValue { get; set; }
    public decimal? VatPercent { get; set; }
    public Image Logo { get; set; }
    public VendorContactResponse Contact { get; set; }
    public List<BankAccountResponse> BankAccount { get; set; }
    public Document Document { get; set; }
    public bool IsPreDelete { get; set; }
    public DateTime? PreDeleteAt { get; set; }
    public bool Editable { get; set; }
    public string CreatedBy { get; set; }
    public bool? IsServiceDocument { get; set; }
}

public class Document
{
    public List<DocumentDetail> JuristicDocuments { get; set; }
    public List<DocumentDetail> IdCardDocuments { get; set; }
    public List<DocumentDetail> TaxDocuments { get; set; }
    public List<DocumentDetail> OtherDocuments { get; set; }
}

public class VendorLocationResponse : Location
{

}

public class VendorContactResponse : VendorContact
{
    public List<PhoneRequest> PhoneNumber { get; set; }
    public ResourceValue Title { get; set; }
    public VendorLocationResponse Location { get; set; }
}