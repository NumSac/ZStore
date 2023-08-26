using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZStore.Application.Api.Products.Queries;
using ZStore.Application.Api.Products.Service;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Presentation.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IProductService _productService;
        public ShopController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(GetAllProductsQuery query)
        {
            return Ok(await _productService.GetAllProducts(query));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            return Ok(await _productService.GetProductbyId(productId));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory([FromQuery] GetProductsByCategoryQuery query)
        {
            return Ok(await _productService.GetProductsByCategory(query));
        }
    }
}
