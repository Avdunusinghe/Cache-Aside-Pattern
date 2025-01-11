using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Models;
using ShoppingCart.API.Pipelines.Command.DeleteShoppingCart;
using ShoppingCart.API.Pipelines.Command.StoreShoppingCart;
using ShoppingCart.API.Pipelines.Query.GetShoppingCart;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController(IMediator mediator) : ControllerBase
    {
        [HttpGet("getShoppingCart/{userName}")]
        public async Task<IActionResult> GetShoppingCart(string userName)
        {
            var products = await mediator.Send(new GetShoppingCartQuery(userName));

            return Ok(products);
        }

        [HttpGet("storeShoppingCart")]
        public async Task<IActionResult> StoreShoppingCart([FromBody] ShoppingCartContainer shoppingCartContainer)
        {
            var products = await mediator.Send(new StoreShoppingCartCommand(shoppingCartContainer));

            return Ok(products);
        }

        [HttpDelete("deleteShoppingCart/{userName}")]
        public async Task<IActionResult> DeleteShoppingCart(string userName)
        {
            var products = await mediator.Send(new DeleteShoppingCartCommand(userName));

            return Ok(products);
        }

    }
}
