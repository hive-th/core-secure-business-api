namespace Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

public class CreateCartRequest
{
    public string CartId { get; set; }
    public string GuestId { get; set; }
    public string DealerId { get; set; }
    public string ProductId { get; set; }
    public string UnitId { get; set; }
    public int Quantity { get; set; }
}