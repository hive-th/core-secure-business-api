using Core.DotNet.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.CartAggregate;

public class CreateCartResponse : CreateResponse
{
    public string GuestId { get; set; }
}