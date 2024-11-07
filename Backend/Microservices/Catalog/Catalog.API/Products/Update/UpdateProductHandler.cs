
using Catalog.API.Exceptions;
using Catalog.API.Products.Create;
using Catalog.API.Products.GetAll;
using FluentValidation;

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

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ProductID is required");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is required");
        }
    }
    public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken) ?? throw new ProductNotFoundException(command.Id);
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
