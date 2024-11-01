using Catalog.API.Products.Create;
using Catalog.API.Products.Update;

namespace Catalog.API.Products.Delete
{
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                return Results.Ok();
            })
             .WithName("DeleteProduct")
             .Produces<CreateProductRequest>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .WithSummary("Delete Product")
             .WithDescription("Delete Product");
        }
    }
}
