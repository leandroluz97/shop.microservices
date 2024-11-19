
namespace Basket.API.Basket.Get
{

    public class GetBasketEndpoints : ICarterModule
    {
        public record GetBasketQueryResponse(ShoppingCart Cart);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username}", async (string username, ISender sender) =>
            {
                var command = new GetBasketQuery(username);
                var result = await sender.Send(command);
                var response = result.Adapt<GetBasketQueryResponse>();
                return Results.Ok(response);
            })
            .WithName("GetBasketQueryByUsermane")
            .Produces<GetBasketQueryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Basket By Query Username")
            .WithDescription("Get Basket By Query Username");
        }
    }
}
