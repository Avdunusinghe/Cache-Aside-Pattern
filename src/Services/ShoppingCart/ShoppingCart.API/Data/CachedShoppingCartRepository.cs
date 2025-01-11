using ShoppingCart.API.Models;

namespace ShoppingCart.API.Data
{
    public class CachedShoppingCartRepository : IShoppingCartRepository
    {
        public Task<bool> DeleteShoppingCart(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartContainer> GetShoppingCart(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartContainer> StoreShoppingCart(ShoppingCartContainer shoppingCart, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
