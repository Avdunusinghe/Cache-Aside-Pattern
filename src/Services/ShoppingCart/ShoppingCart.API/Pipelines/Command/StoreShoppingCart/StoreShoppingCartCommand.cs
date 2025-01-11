using ShoppingCart.API.Models;

namespace ShoppingCart.API.Pipelines.Command.StoreShoppingCart
{
    public record StoreShoppingCartCommand(ShoppingCartContainer ShoppingCartContainer) : IRequest<ResultDTO>;

    public class StoreShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        : IRequestHandler<StoreShoppingCartCommand, ResultDTO>
    {
        public async Task<ResultDTO> Handle(StoreShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await shoppingCartRepository.StoreShoppingCart(request.ShoppingCartContainer, cancellationToken);

            return ResultDTO.Success("Shpping Cart Successfully Stored.");
        }
    }
}
