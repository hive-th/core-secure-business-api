using Core.DotNet.AggregatesModel.LocationAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;

public class ShippingLocation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ShippingLocationReceiver Receiver { get; set; }
    public Location Location { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class ShippingLocationReceiver
{
    public string TitleCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<string> PhoneNumbers { get; set; }
}
