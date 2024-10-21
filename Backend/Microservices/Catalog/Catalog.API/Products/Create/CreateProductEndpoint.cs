using Carter;
using Common.CQRS;
using Mapster;
using MediatR;

namespace Catalog.API.Products.Create
{
    public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

    public record CreatProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("/prodcuts", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreatProductResponse>();
                return Results.Created($"/products/{response.Id}", response);
            });
        }
    }
}
