using Microsoft.EntityFrameworkCore;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Models;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        /*
        public async Task AddProductToShoppingCart(string userId, Product product)
        {
            var shoppingCart = await GetOrCreateShoppingCartAsync(userId);
            shoppingCart.ProductIds.Add(product.Id);
        }

        public async Task UpdateShoppingCartContents(string userId, Product product)
        {
            var shoppingCart = await GetOrCreateShoppingCartAsync(userId);

            // Update shopping cart logic
        }

        public async Task DeleteFromShoppingCart(string userId, int productId)
        {
            var shoppingCart = await GetOrCreateShoppingCartAsync(userId);

            if (shoppingCart.ProductIds.Contains(productId))
            {
                shoppingCart.ProductIds.Remove(productId);
            }
            else
            {
                throw new DbException($"Product with id {productId} not found in Cart");
            }
        }

        private async Task<ShoppingCart> GetOrCreateShoppingCartAsync(string userId)
        {
            var shoppingCart = await _context.ShoppingCarts
                .FirstOrDefaultAsync(sc => sc.ApplicationUserId == userId);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart { ApplicationUserId = userId };
                _context.ShoppingCarts.Add(shoppingCart);
            }

            return shoppingCart;
        }
        */
    }
}
