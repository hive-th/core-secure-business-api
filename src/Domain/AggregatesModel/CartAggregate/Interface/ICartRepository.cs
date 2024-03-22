using Core.DotNet.Infrastructure;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;

namespace Core.Secure.Business.Domain.AggregatesModel.CartAggregate.Interface;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart> GetCartByIdAsync(Guid cartId, bool asNoTracking = false);
    Task<Cart> GetCartByUserIdAsync(string userId, bool asNoTracking = false);
    Task<Cart> GetCartByGuestIdAsync(string guestId, bool asNoTracking = false);
}