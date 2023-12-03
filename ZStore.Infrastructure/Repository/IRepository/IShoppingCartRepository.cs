using ZStore.Domain.Models;

namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
       /*
        Task AddProductToShoppingCart(string userId, Product product);
        Task DeleteFromShoppingCart(string userId, int productId);
        Task UpdateShoppingCartContents(string userId, Product product);
       */
    }
}
