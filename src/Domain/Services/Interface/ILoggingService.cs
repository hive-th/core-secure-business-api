using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.LoggingAggregate;

namespace Core.Secure.Business.Domain.Services.Interface;

public interface ILoggingService
{
    Task<CreateResponse> LogInfo(string referenceType, string referenceId, string source, string description, LogObjectType objectType, object objectValue);
    Task<CreateResponse> LogError(string referenceType, string referenceId, string source, string description, LogObjectType objectType, object objectValue);
}