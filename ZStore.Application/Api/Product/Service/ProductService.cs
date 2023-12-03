using ZStore.Application.Api.Interfaces;
using ZStore.Application.Api.Product.Queries;
using ZStore.Application.Api.Product.Queries.GetProductsByCategory;
using ZStore.Application.DTOs;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<IEnumerable<ProductDTO>>> GetAllProducts(GetAllProductsQuery query)
        {
            var result = _unitOfWork.Product.GetAll(includeProperties: "Category");

            var transformedResult = result.Select(p => new ProductDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Category = p.Category.Name,
            }).ToList();

            return new PagedResponse<IEnumerable<ProductDTO>>(transformedResult, 
                query.PageNumber, query.PageSize
                );
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

        public async Task<PagedResponse<IEnumerable<ProductDTO>>> GetProductsByCategory(GetProductsByCategoryQuery query)
        {
            var products = await _unitOfWork.Product.GetProductsByCategoryAsync(query.CategoryName);

            var transformedResult = products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Category = p.Category.Name,
            }).ToList();


            return new PagedResponse<IEnumerable<ProductDTO>>(transformedResult, 
                query.PageNumber, 
                query.PageSize
                );
        }
    }
}
