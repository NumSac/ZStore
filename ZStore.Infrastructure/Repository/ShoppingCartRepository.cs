using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
