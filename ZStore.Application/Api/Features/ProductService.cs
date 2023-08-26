using ZStore.Application.DTOs;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Features
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<ProductDTO>>> GetAllProducts()
        {
            var result = _unitOfWork.Product.GetAll(includeProperties: "Category");

            var transformedResult = result.Select(p => new ProductDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Category = p.Category.Name,
            }).ToList();

            return new Response<List<ProductDTO>>(transformedResult);
        }

        public async Task<Response<ProductDTO>> GetProductbyId(int id)
        {
            var result = await _unitOfWork.Product.GetByIdAsync(id);
            if (result == null)
                return new Response<ProductDTO>(new ProductDTO());

            return new Response<ProductDTO>(new ProductDTO
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Category = result.Category.Name,
            });
        }

        public async Task<Response<List<Product>>> GetProductsByCategory(string categoryName)
        {
            var products = await _unitOfWork.Product.GetProductsByCategoryAsync(categoryName);

            if (products.Count == 0)
            {
                return new Response<List<Product>>("No products found for the provided category.");
            }

            return new Response<List<Product>>(products, "Products retrieved successfully.");
        }
    }
}
