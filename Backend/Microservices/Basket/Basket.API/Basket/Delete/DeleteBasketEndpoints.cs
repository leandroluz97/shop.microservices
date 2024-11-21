
namespace Basket.API.Basket.Delete
{
    public record DeleteBasketRequest(string Username);
    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{username}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(username));
                return Results.Ok();
            })
             .WithName("BasketProduct")
             .Produces(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .WithSummary("Delete Basket")
             .WithDescription("Delete Basket");
        }
    }
}
