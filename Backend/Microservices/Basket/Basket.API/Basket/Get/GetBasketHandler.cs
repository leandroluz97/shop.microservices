using Basket.API.Data;

namespace Basket.API.Basket.Get
{
    public record GetBasketQuery(string Username) : IQuery<GetBasketQueryResult>;
    public record GetBasketQueryResult(ShoppingCart Cart);
    public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketQueryResult>
    {
        public async Task<GetBasketQueryResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasket(query.Username, cancellationToken)
                .ConfigureAwait(false);
            return new GetBasketQueryResult(basket);
        }
    }
}
