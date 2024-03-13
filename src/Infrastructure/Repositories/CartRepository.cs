using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Core.Secure.Business.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Http;

namespace Core.Secure.Business.Infrastructure.Repositories;

public class CartRepository : BaseRepository<BusinessDbContext, Cart>, ICartRepository
{
    public CartRepository(BusinessDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
    {

    }
}