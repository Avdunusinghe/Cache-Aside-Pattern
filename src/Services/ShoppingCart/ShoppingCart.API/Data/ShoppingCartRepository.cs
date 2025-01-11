﻿using ShoppingCart.API.Exceptions;
using ShoppingCart.API.Models;

namespace ShoppingCart.API.Data
{
    public class ShoppingCartRepository(IDocumentSession session) : IShoppingCartRepository
    {
        public async Task<bool> DeleteShoppingCart(string userName, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCartContainer>(userName);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<ShoppingCartContainer> GetShoppingCart(string userName, CancellationToken cancellationToken = default)
        {
            var shoppingCart = await session.LoadAsync<ShoppingCartContainer>(userName, cancellationToken);

            return shoppingCart is null ? throw new ShoppingCartNotFoundException(userName) : shoppingCart;
        }

        public async Task<ShoppingCartContainer> StoreShoppingCart(ShoppingCartContainer shoppingCart, CancellationToken cancellationToken = default)
        {
            session.Store(shoppingCart);
            await session.SaveChangesAsync(cancellationToken);
            return shoppingCart;
        }
    }
}