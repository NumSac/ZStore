using ZStore.Domain.Models;

namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task<ShoppingCart> GetOrCreateShoppingCartAsync(string userId);
    }
}
