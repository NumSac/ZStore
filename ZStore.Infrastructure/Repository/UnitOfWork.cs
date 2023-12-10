using Microsoft.EntityFrameworkCore.Storage;
using ZStore.Domain.Exceptions;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductImageRepository ProductImage { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICompanyProfileRepository CompanyProfile { get; private set; }
        public IProductDetailRepository ProductDetail { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IShoppingCartItemRepository ShoppingCartItem { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ApplicationUser = new ApplicationUserRepository(_context);
            Company = new CompanyRepository(_context);
            ProductImage = new ProductImageRepository(_context);
            Product = new ProductRepository(_context);
            Category = new CategoryRepository(_context);
            CompanyProfile = new CompanyProfileRepository(_context);
            ProductDetail = new ProductDetailRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);
            OrderHeader = new OrderHeaderRepository(_context);
            ShoppingCart = new ShoppingCartRepository(_context);
            ShoppingCartItem = new ShoppingCartItemRepository(_context);
        }

        public IDbContextTransaction BeginTransaction ()
        {
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
            }
            throw new DbException("Db Transaction is not initialized");
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
            throw new DbException("Db Transaction is not initialized");
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
