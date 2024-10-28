namespace Catalog.API.Products.GetById
{
    public record GetProductResponse(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var command = new GetProductByIdQuery(id) ;
                var result = await sender.Send(command);
                var response = result.Adapt<GetProductResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductById ")
            .Produces<GetProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
        }
    }
}
