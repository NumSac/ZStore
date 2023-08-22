using Microsoft.EntityFrameworkCore.Storage;

namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }
        ICompanyRepository Company { get; }
        IProductImageRepository ProductImage { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void Rollback();
        public Task SaveAsync();
    }
}
