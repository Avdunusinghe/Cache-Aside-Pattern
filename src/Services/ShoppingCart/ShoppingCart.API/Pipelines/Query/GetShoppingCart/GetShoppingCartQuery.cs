using ShoppingCart.API.Models;

namespace ShoppingCart.API.Pipelines.Query.GetShoppingCart
{

    public record GetShoppingCartQuery(string UserName) : IRequest<ShoppingCartContainer>;
    public class GetShoppingCartQueryHandler(IShoppingCartRepository shoppingCartRepository)
        : IRequestHandler<GetShoppingCartQuery, ShoppingCartContainer>
    {
        public async Task<ShoppingCartContainer> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await shoppingCartRepository.GetShoppingCartAsync(request.UserName);

            return shoppingCart;
        }
    }
}
