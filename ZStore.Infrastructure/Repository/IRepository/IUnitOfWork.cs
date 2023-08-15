namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUser { get; }
        ICompanyRepository Company { get; }
        IProductImageRepository ProductImage { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }  

        public Task SaveAsync();
    }
}
