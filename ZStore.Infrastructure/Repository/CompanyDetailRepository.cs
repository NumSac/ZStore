using ZStore.Domain.Models;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class CompanyProfileRepository : Repository<CompanyProfile>, ICompanyProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
