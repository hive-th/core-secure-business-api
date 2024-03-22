using Core.Secure.Business.Domain.AggregatesModel.FacadesAggregate;

namespace Core.Secure.Business.Domain.Facades.Interface;

public interface IOrderFacade
{
    Task<FacadesResponse> PlaceOrderAsync(Guid cartId);
}