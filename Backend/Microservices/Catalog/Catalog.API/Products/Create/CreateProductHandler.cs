using Catalog.API.Models;
using Common.CQRS;
using MediatR;

namespace Catalog.API.Products.Create
{
    public record CreateProductCommand(
        string Name, 
        List<string> Category, 
        string Description, 
        string ImageFile, 
        decimal Price) : ICommand<CreatProductResult>;

    public record CreatProductResult(Guid Id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreatProductResult>
    {
        public async Task<CreatProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            return new CreatProductResult(Guid.NewGuid());  
        }
    }
}
