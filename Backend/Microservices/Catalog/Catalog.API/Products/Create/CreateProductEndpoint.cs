using Common.CQRS;

namespace Catalog.API.Products.Create
{
    public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

    public record CreatProductResponse(Guid Id);
    public class CreateProductEndpoint
    {
    }
}
