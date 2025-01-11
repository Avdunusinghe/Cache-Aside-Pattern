using ShoppingCart.API.Models;

namespace ShoppingCart.API.Data
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCartContainer> GetShoppingCart(
            string userName,
            CancellationToken cancellationToken = default);
        Task<ShoppingCartContainer> StoreShoppingCart(
            ShoppingCartContainer shoppingCart,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteShoppingCart(
            string userName,
            CancellationToken cancellationToken = default);
    }
}
