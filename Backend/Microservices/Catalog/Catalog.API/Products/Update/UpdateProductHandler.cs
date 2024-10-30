
using Catalog.API.Exceptions;

namespace Catalog.API.Products.Update
{
    public record UpdateProductCommand(
       Guid Id,
       string Name,
       List<string> Category,
       string Description,
       string ImageFile,
       decimal Price) : ICommand<UpdateProductResult>;

    public record UpdateProductResult(
        Guid Id,
       string Name,
       List<string> Category,
       string Description,
       string ImageFile,
       decimal Price);
    public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken) ?? throw new ProductNotFoundException();
            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(
                product.Id,
                product.Name,
                product.Category,
                product.Description,
                product.ImageFile,
                product.Price);
        }
    }
}
