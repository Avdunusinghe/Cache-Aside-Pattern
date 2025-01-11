using Microsoft.Extensions.Caching.Distributed;
using ShoppingCart.API.Models;
using System.Text.Json;

namespace ShoppingCart.API.Data
{
    public class CachedShoppingCartRepository
        (IShoppingCartRepository repository,
        IDistributedCache cache) : IShoppingCartRepository
    {
        public async Task<ShoppingCartContainer> GetShoppingCart(string userName, CancellationToken cancellationToken = default)
        {
            var cachedShoppingCart = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cachedShoppingCart))
                return JsonSerializer.Deserialize<ShoppingCartContainer>(cachedShoppingCart)!;

            var shoppingCart = await repository.GetShoppingCart(userName, cancellationToken);
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(shoppingCart), cancellationToken);
            return shoppingCart;
        }

        public async Task<ShoppingCartContainer> StoreShoppingCart(ShoppingCartContainer shoppingCart, CancellationToken cancellationToken = default)
        {
            await repository.StoreShoppingCart(shoppingCart, cancellationToken);

            await cache.SetStringAsync(shoppingCart.UserName, JsonSerializer.Serialize(shoppingCart), cancellationToken);

            return shoppingCart;
        }

        public async Task<bool> DeleteShoppingCart(string userName, CancellationToken cancellationToken = default)
        {
            await repository.DeleteShoppingCart(userName, cancellationToken);

            await cache.RemoveAsync(userName, cancellationToken);

            return true;
        }


    }
}
