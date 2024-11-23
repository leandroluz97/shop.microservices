
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache) : IBasketRepository
    {
        public async Task DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            await repository.DeleteBasket(username, cancellationToken);
            await cache.RemoveAsync(username, cancellationToken);
        }

        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            var chachedBasket = await cache.GetStringAsync(username, cancellationToken);
            if (!string.IsNullOrEmpty(chachedBasket))
            {
                return JsonSerializer.Deserialize<ShoppingCart>(chachedBasket)!;
            }
            var basket = await repository.GetBasket(username, cancellationToken);
            await cache.SetStringAsync(username, JsonSerializer.Serialize(basket), token: cancellationToken);
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart card, CancellationToken cancellationToken = default)
        {
            var basket = await repository.StoreBasket(card, cancellationToken);
            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), token: cancellationToken);
            return basket;
        }
    }
}
