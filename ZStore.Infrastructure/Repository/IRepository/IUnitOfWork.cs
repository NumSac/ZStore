using Microsoft.EntityFrameworkCore.Storage;

namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }
        ICompanyRepository Company { get; }
        IProductImageRepository ProductImage { get; }
        IProductRepository Product { get; }
        IProductDetailRepository ProductDetail { get; }
        ICategoryRepository Category { get; }
        ICompanyProfileRepository CompanyProfile { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IShoppingCartRepository ShoppingCart { get; }

        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void Rollback();
        public Task SaveAsync();
    }
}
