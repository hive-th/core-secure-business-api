using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.DotNet.AggregatesModel.LocationAggregate;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate;

public class CustomerVendorResponse
{
    public Guid Id { get; set; }
    public Guid CustomerTierId { get; set; }
    public Guid VendorId { get; set; }
    public Guid AccountId { get; set; }
    public string CustomerType { get; set; } //JURISTIC
    public string CustomerStatus { get; set; }
    public bool UseUserProfile { get; set; }
    public CustomerUserData UserProfile { get; set; }
    public bool UseCompanyProfile { get; set; }
    public CustomerCompanyData CompanyProfile { get; set; }
    public List<Image> Document { get; set; }
    public bool IsActive { get; set; }
}

public class CustomerUserData
{
    public Locale FirstName { get; set; }
    public Locale LastName { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
    public List<PhoneRequest> PhoneNumber { get; set; }
    public List<PhoneRequest> FaxNumber { get; set; }
    public List<string> Email { get; set; }
}

public class CustomerCompanyData
{
    public Locale Name { get; set; }
    public CustomerLocationRequest Location { get; set; }
    public List<PhoneRequest> PhoneNumber { get; set; }
    public List<PhoneRequest> FaxNumber { get; set; }
    public List<string> Email { get; set; }
    public string TaxId { get; set; }
}

public class CustomerLocationRequest : Location
{
    
}