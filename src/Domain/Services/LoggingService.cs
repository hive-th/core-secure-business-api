using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Core.DotNet.AggregatesModel.CommonAggregate;
using Core.DotNet.Extensions.Utilities;
using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Core.Secure.Business.Domain.AggregatesModel.LoggingAggregate;
using Core.Secure.Business.Domain.AggregatesModel.LoggingAggregate.Interface;
using Core.Secure.Business.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Domain.Services;

public class LoggingService : ILoggingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogSystemRepository _logSystemRepository;
    
    public LoggingService(IUnitOfWork unitOfWork, 
        IHttpContextAccessor httpContextAccessor, 
        ILogSystemRepository logSystemRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _logSystemRepository = logSystemRepository ?? throw new ArgumentNullException(nameof(logSystemRepository));
        DateTimeExtensions.SetCultureInfo("en-US");
    }

    public async Task<CreateResponse> LogInfo(string referenceType, string referenceId, string source, string description, LogObjectType objectType, object objectValue)
    {
        return await LogSystem(LogType.Info, referenceType, referenceId, source, description, objectType, objectValue);
    }

    public async Task<CreateResponse> LogError(string referenceType, string referenceId, string source, string description, LogObjectType objectType, object objectValue)
    {
        return await LogSystem(LogType.Error, referenceType, referenceId, source, description, objectType, objectValue);
    }

    private async Task<CreateResponse> LogSystem(LogType logType, string referenceType, string referenceId, string source, string description, LogObjectType objectType, object objectValue)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.Preserve
        };

        var log_system_id = Guid.NewGuid();
        var logSystem = new LogSystem
        {
            Id = log_system_id,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = _httpContextAccessor.GetUserId(),
            UpdatedAt = DateTime.UtcNow,
            UpdatedBy = _httpContextAccessor.GetUserId(),
            Type = logType,
            ReferenceType = referenceType,
            ReferenceId = referenceId,
            Source = source,
            Description = description,
            ObjectType = objectType,
            ObjectValue = objectValue is null ? null : JsonSerializer.Serialize(objectValue, options)
        };
        
        _logSystemRepository.Insert(logSystem);
        _unitOfWork.SaveChanges();
        
        return new CreateResponse
        {
            Id = log_system_id
        };
    }
}