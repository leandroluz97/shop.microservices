
using Common.Pagination;
using Ordering.Application.Orders.Queries.GetOrders;

namespace Ordering.API.Endpoints
{
    public record GetOrdersResponse(PaginationResult<OrderDto> Orders);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationOptions options, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersQuery(options));
                var response = result.Adapt<GetOrdersResponse>();
                return Results.Ok(response);

            })
            .WithName("GetOrders")
            .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders")
            .WithDescription("Get Orders");
        }
    }
}
