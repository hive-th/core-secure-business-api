namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.PaymentAggregate;

public class Payment
{
    public PaymentProvider PaymentProvider { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentCard Card { get; set; }
}

public class PaymentCard
{
    public Guid Id { get; set; }
    public PaymentProvider PaymentProvider { get; set; }
    public string LastDigits { get; set; }
    public string CardBrand { get; set; }
    public bool IsDefault { get; set; }
}

public enum PaymentMethod
{
    CARD,
    THAI_QR
}

public enum PaymentProvider
{
    MC_Payment,
    GB_Payment
}