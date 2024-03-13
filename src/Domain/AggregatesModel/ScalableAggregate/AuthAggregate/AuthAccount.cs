namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.AuthAggregate;

public class AuthAccount
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public string TitleCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AuthAccountImage Image { get; set; }
    public string PhoneCode { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? LastActive { get; set; }
}

public class AuthAccountImage
{
    public string BaseUri { get; set; }
    public string FilePath { get; set; }
}