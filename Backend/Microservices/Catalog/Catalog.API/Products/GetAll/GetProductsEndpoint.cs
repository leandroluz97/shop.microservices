
using Catalog.API.Products.Create;

namespace Catalog.API.Products.GetAll
{

    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
             .WithName("GetProducts")
             .Produces<GetProductsResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .WithSummary("Get Products")
             .WithDescription("Get all Products");
        }
    }
}
