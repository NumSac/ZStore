using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Models;

namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company?> GetCompanyFromUserCompanyIdAsync(ApplicationUser user);
    }
}
