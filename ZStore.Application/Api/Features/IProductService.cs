using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Application.DTOs;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;

namespace ZStore.Application.Api.Features
{
    public interface IProductService
    {
        Task<Response<List<ProductDTO>>> GetAllProducts();
        Task<Response<ProductDTO>> GetProductbyId(int id);
        Task<Response<List<Product>>> GetProductsByCategory(string categoryName);
    }
}
