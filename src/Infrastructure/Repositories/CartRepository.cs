using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.CartAggregate.Interface;
using Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Core.Secure.Business.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.Secure.Business.Infrastructure.Repositories;

public class CartRepository : BaseRepository<BusinessDbContext, Cart>, ICartRepository
{
    public CartRepository(BusinessDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
    {

    }
    
    public async Task<Cart> GetCartByIdAsync(Guid cartId, bool asNoTracking = false)
    {
        var query = Context.Carts.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTrackingWithIdentityResolution();

        var result = await query.FirstOrDefaultAsync(m => m.Id == cartId);

        return result;
    }

    public async Task<Cart> GetCartByUserIdAsync(string userId, bool asNoTracking = false)
    {
        var query = Context.Carts.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTrackingWithIdentityResolution();

        var result = await query.FirstOrDefaultAsync(m => m.CreatedBy == userId);

        return result;
    }

    public async Task<Cart> GetCartByGuestIdAsync(string guestId, bool asNoTracking = false)
    {
        var query = Context.Carts.AsQueryable();

        if (asNoTracking)
            query = query.AsNoTrackingWithIdentityResolution();

        var result = await query.FirstOrDefaultAsync(m => m.GuestId == guestId 
                                                          && m.CartType == CartType.GUEST_USER);

        return result;
    }
}