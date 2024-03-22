namespace Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

public class CartValidationResponse
{
    public string FieldName { get; set; }
    public string ReferenceId { get; set; }
    public string ErrorMessage { get; set; }
}