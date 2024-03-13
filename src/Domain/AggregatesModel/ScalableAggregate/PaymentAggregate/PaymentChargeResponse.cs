namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate;

public class PaymentChargeResponse
{
    public string ChargeId { get; set; }
    public string Status { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentProvider { get; set; }
    public string Message { get; set; }
    public CardInformationResponse CardInformation { get; set; }
}

public class CardInformationResponse
{
    public Guid Id { get; set; }
    public string LastDigits { get; set; }
    public string CardBrand { get; set; }
    public bool IsDefault { get; set; }
}
