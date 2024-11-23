
namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository repository) : IBasketRepository
    {
        public async Task DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
           await repository.DeleteBasket(username, cancellationToken);
        }

        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            var basket = await repository.GetBasket(username, cancellationToken);
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart card, CancellationToken cancellationToken = default)
        {
            var basket = await repository.StoreBasket(card, cancellationToken);
            return basket;
        }
    }
}
