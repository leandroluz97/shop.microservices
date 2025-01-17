﻿


using Basket.API.Exceptions;

namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {  
        public async Task DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCart>(username);
            await session.SaveChangesAsync(cancellationToken);
        }

        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken = default)
        {
           var basket =  await session.LoadAsync<ShoppingCart>(username, cancellationToken)
                ?? throw new BasketNotFoundException(username);
           return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            session.Store<ShoppingCart>(basket);
            await session.SaveChangesAsync(cancellationToken);
            return basket;
        }
    }
}
