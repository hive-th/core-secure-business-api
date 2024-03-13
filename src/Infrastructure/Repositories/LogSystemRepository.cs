using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Core.Secure.Business.Domain.AggregatesModel.LoggingAggregate.Interface;
using Core.Secure.Business.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Infrastructure.Repositories;

public class LogSystemRepository : BaseRepository<BusinessDbContext, LogSystem>, ILogSystemRepository
{
    public LogSystemRepository(BusinessDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
    {

    }
}