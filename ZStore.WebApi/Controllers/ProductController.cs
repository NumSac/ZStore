using Microsoft.AspNetCore.Mvc;
using ZStore.Application.Features;

namespace ZStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategory([FromQuery] string category)
        {
            return Ok(await _productService.GetProductsByCategory(category));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _productService.GetProductbyId(id));
        }
    }
}
