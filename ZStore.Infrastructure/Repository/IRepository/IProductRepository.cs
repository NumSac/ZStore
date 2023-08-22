using ZStore.Domain.Models;

namespace ZStore.Infrastructure.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductsByCategoryAsync(string categoryName);
    }
}
