namespace Basket.API.Basket.Get
{
    public record GetBasketQuery(string Username) : IQuery<GetBasketQueryResult>;
    public record GetBasketQueryResult(ShoppingCart Cart);
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketQueryResult>
    {
        public async Task<GetBasketQueryResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return new GetBasketQueryResult(new ShoppingCart("Leandro"));
        }
    }
}
