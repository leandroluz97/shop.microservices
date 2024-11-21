namespace Basket.API.Basket.Store
{
    public record StoreBasketRequest(string UserName, List<ShoppingCartItem> Items);
    public record StoreBasketResponse(string UserName, List<ShoppingCartItem> Items, decimal TotalPrice);
    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketRequest>();
                var result = await sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();
                return Results.Created($"/basket/{response.UserName}", response);
            })
            .WithName("StoreBasket")
            .Produces<StoreBasketRequest>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Store Basket")
            .WithDescription("Store Basket");
        }
    }
}
