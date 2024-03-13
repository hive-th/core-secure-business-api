using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Core.Secure.Business.Domain.AggregatesModel.OrderAggregate.Interface;
using Core.Secure.Business.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Infrastructure.Repositories;

public class OrderRequestRepository : BaseRepository<BusinessDbContext, OrderRequest>, IOrderRequestRepository
{
    public OrderRequestRepository(BusinessDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
    {

    }
}