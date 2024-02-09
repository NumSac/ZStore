using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using ZStore.Application.Api.Cart.Commands.AddItemToShoppingCart;
using ZStore.Application.Api.Cart.Commands.RemoveItemFromShoppingCart;
using ZStore.Application.Api.Cart.Commands.UpdateItemFromShoppingCart;
using ZStore.Application.Api.Cart.Queries.GetShoppingCart;
using ZStore.Domain.Utils;

namespace ZStore.Presentation.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ShoppingCartController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetShoppingCartParameter filter)
        {
            return Ok(await Mediator.Send(new GetShoppingCartQuery { OwnerId = filter.OwnerId, PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddItemToShoppingCartParameter filter)
        {
            return Ok(await Mediator.Send(new AddItemToShoppingCartCommand { OwnerId = filter.OwnerId, ItemId = filter.ItemId, Count = filter.ItemCount }));
        }

        [HttpPut]
        public async Task<IActionResult> Get([FromBody] UpdateItemFromShoppingCartParameter filter)
        {
            return Ok(await Mediator.Send(new UpdateItemFromShoppingCartCommand { OwnerId = filter.OwnerId, ItemId = filter.ItemId, Count = filter.ItemCount }));
        }
    }
}
