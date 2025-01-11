using ShoppingCart.API.Models;

namespace ShoppingCart.API.Data
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCartContainer> GetShoppingCartAsync(
            string userName,
            CancellationToken cancellationToken = default);
        Task<ShoppingCartContainer> StoreShoppingCartAsync(
            ShoppingCartContainer shoppingCart,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteShoppingCartAsync(
            string userName,
            CancellationToken cancellationToken = default);
    }
}
