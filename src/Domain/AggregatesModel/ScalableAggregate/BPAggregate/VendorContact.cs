namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate;

public class VendorContact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> Email { get; set; }
}