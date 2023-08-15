using ZStore.Domain.Models;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Company?> GetCompanyFromUserCompanyIdAsync(ApplicationUser user)
        {
            if (user.CompanyId != null) return null;

            var company = await _context.Companies.FindAsync(user.CompanyId);

            if (company == null) return null;

            return company;
        }
    }
}
