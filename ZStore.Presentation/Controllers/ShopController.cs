using Microsoft.AspNetCore.Mvc;
using ZStore.Application.Api.Features;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IProductService _productService;
        public ShopController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }
    }
}
