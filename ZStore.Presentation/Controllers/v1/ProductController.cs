using Microsoft.AspNetCore.Mvc;
using ZStore.Application.Api.Product.Queries;
using ZStore.Application.Api.Product.Queries.GetAllProductsPaged;
using ZStore.Application.Api.Product.Queries.GetProductById;
using ZStore.Application.Api.Product.Queries.GetProductsByCategory;

namespace ZStore.Presentation.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        // GET api/<controller>/?
        [HttpGet("category")]
        public async Task<IActionResult> Get([FromQuery] GetProductsByCategoryParameter filter)
        {
            return Ok(await Mediator.Send(new GetProductsByCategoryQuery { 
                CategoryName = filter.CategoryName, 
                PageNumber = filter.PageNumber, 
                PageSize = filter.PageSize 
            }));
        }
    }
}
