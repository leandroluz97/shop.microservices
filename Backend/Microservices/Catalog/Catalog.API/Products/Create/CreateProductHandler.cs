using FluentValidation;

namespace Catalog.API.Products.Create
{
    public record CreateProductCommand(
        string Name, 
        List<string> Category, 
        string Description, 
        string ImageFile, 
        decimal Price) : ICommand<CreatProductResult>;

    public record CreatProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
        }
    }
    public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreatProductResult>
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

            session.Store(product);
            await session.SaveChangesAsync();

            return new CreatProductResult(product.Id);  
        }
    }
}
