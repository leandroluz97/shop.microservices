namespace Catalog.API.Products.GetByCategory
{
    public record GetProductsByCategoryResult(IEnumerable<Product> Products);
    public class GetProductsByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var command = new GetProductByCategoryQuery(category);
                var result = await sender.Send(command);
                var response = result.Adapt<GetProductsByCategoryResult>();
                return Results.Ok(response);
            })
            .WithName("GetProductsByCategory")
            .Produces<GetProductsByCategoryResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Products By Category")
            .WithDescription("Get Products By Category");
        }
    }
}
