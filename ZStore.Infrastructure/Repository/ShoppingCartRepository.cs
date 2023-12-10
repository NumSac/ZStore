using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<ShoppingCart> GetOrCreateShoppingCartAsync(string userId)
        {
            // Check if a shopping cart for the user already exists
            var existingCart = _context.ShoppingCarts 
                .SingleOrDefault(cart => cart.ApplicationUserId == userId);

            if (existingCart != null)
            {
                return existingCart;
            }
            else
            {
                // If no cart exists, create a new shopping cart for the user
                var newCart = new ShoppingCart
                {
                    ApplicationUserId = userId,
                };
                _context.ShoppingCarts.Add(newCart);
                await _context.SaveChangesAsync();

                return newCart;
            }
        }
    }
}
