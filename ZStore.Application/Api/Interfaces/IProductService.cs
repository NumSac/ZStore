using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Application.Api.Product.Queries;
using ZStore.Application.DTOs;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;

namespace ZStore.Application.Api.Interfaces
{
    public interface IProductService
    {
        Task<PagedResponse<IEnumerable<ProductDTO>>> GetAllProducts(GetAllProductsQuery query);
        Task<Response<ProductDTO>> GetProductbyId(int id);
        Task<PagedResponse<IEnumerable<ProductDTO>>> GetProductsByCategory(GetProductsByCategoryQuery query);
    }
}
