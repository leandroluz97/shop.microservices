using Ordering.Application.Orders.Queries.GetOrderByName;

namespace Ordering.API.Endpoints
{
    public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);
    public class GetOrdersByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
            {
                var result = await sender.Send(new GetOrderByNameQuery(orderName));
                var response = result.Adapt<GetOrderByNameResponse>();
                return Results.Ok(response);

            })
            .WithName("GetOrderByName")
            .Produces<DeleteOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Order By Name")
            .WithDescription("Get Order By Name");
        }
    }
}
