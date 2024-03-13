using Core.DotNet.AggregatesModel.LocationAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;

public class TaxLocation
{
    public Guid Id { get; set; }
    public bool IsDefault { get; set; }
    public bool IsRemove { get; set; }
    public string Name { get; set; }
    public string BusinessType { get; set; }
    public string TaxId { get; set; }
    public string IdCard { get; set; }
    public List<string> PhoneNumbers { get; set; }
    public TaxLocationCompany Company { get; set; }
    public TaxLocationIndividual Individual { get; set; }
    public Location Location { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class TaxLocationCompany
{
    public string Name { get; set; }
    public string BranchNumber { get; set; }
}

public class TaxLocationIndividual
{
    public string TitleCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
