using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.API.Pipelines.Query.GetProductItems;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController(IMediator mediator) : ControllerBase
    {
        [HttpGet("getProductItems")]
        public async Task<IActionResult> GetProductItems()
        {
            var products = await mediator.Send(new GetProductItemsQuery());
            return Ok(products);
        }
    }
}
