using MediatR;

namespace Catalog.API.Products.Create
{
    public record CreateProductCommand(
        string Name, 
        List<string> Category, 
        string Description, 
        string ImageFile, 
        decimal Price) : IRequest<CreatProductResult>;

    public record CreatProductResult(Guid Id);
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatProductResult>
    {
        public Task<CreatProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
