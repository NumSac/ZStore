using ZStore.Domain.Common;
using ZStore.Domain.Models;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
