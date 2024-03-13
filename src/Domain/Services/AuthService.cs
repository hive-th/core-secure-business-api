using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.AuthAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate.Interface;
using Core.Secure.Business.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace Core.Secure.Business.Domain.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthRepository _authRepository;
    private readonly IBPRepository _bpRepository;

    private readonly IDistributedCache _distributedCache;

    public AuthService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        IAuthRepository authRepository,
        IBPRepository bpRepository,
        IDistributedCache distributedCache)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        _bpRepository = bpRepository ?? throw new ArgumentNullException(nameof(bpRepository));
        _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
    }
}