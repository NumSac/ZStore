using ZStore.Domain.Models;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
