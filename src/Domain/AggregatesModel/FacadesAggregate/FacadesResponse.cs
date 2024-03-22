using Core.DotNet.AggregatesModel.CommonAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.FacadesAggregate;

public class FacadesResponse : UpdateResponse
{
    public string Message { get; set; }
}