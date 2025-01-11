using Microsoft.AspNetCore.Mvc;
using Product.API.Pipelines.Command.CreateProductItem;
using Product.API.Pipelines.Command.DeleteProductItem;
using Product.API.Pipelines.Command.UpdateProductItem;
using Product.API.Pipelines.Query.GetProductItemById;
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

        [HttpGet("{id:length(24)}", Name = "getProductItemById")]
        public async Task<IActionResult> GetProductItem(string id)
        {
            var product = await mediator.Send(new GetProductItemByIdQuery(id));

            return Ok(product);
        }


        [HttpGet("getProductItemByCategory/{category}")]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            var product = await mediator.Send(new GetProductItemByIdQuery(category));

            return Ok(product);
        }

        [HttpPost("updateProductItem")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductItemDTO productItemDTO)
        {
            var product = await mediator.Send(new UpdateProductItemCommand(productItemDTO));

            return Ok(product);
        }

        [HttpPost("createProductItem")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductItemDTO productItemDTO)
        {
            var product = await mediator.Send(new CreateProductCommand(productItemDTO));

            return Ok(product);
        }

        [HttpDelete("{id:length(24)}", Name = "deleteProductItem")]
        public async Task<IActionResult> DeleteProductItem(string id)
        {
            var product = await mediator.Send(new DeleteProductItemCommand(id));

            return Ok(product);
        }
    }
}
