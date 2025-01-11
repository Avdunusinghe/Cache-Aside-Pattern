using Microsoft.Extensions.Caching.Distributed;
using ShoppingCart.API.Models;
using System.Text.Json;

namespace ShoppingCart.API.Data
{
    public class CachedShoppingCartRepository
        (IShoppingCartRepository repository,
        IDistributedCache cache) : IShoppingCartRepository
    {
        public async Task<ShoppingCartContainer> GetShoppingCartAsync(string userName, CancellationToken cancellationToken = default)
        {
            var cachedShoppingCart = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cachedShoppingCart))
                return JsonSerializer.Deserialize<ShoppingCartContainer>(cachedShoppingCart)!;

            var shoppingCart = await repository.GetShoppingCartAsync(userName, cancellationToken);
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(shoppingCart), cancellationToken);
            return shoppingCart;
        }

        public async Task<ShoppingCartContainer> StoreShoppingCartAsync(ShoppingCartContainer shoppingCart, CancellationToken cancellationToken = default)
        {
            await repository.StoreShoppingCartAsync(shoppingCart, cancellationToken);

            await cache.SetStringAsync(shoppingCart.UserName, JsonSerializer.Serialize(shoppingCart), cancellationToken);

            return shoppingCart;
        }

        public async Task<bool> DeleteShoppingCartAsync(string userName, CancellationToken cancellationToken = default)
        {
            await repository.DeleteShoppingCartAsync(userName, cancellationToken);

            await cache.RemoveAsync(userName, cancellationToken);

            return true;
        }


    }
}
