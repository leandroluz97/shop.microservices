using Catalog.API.Exceptions;
using Catalog.API.Products.Update;
using FluentValidation;

namespace Catalog.API.Products.Delete
{
    public record DeleteProductCommand(Guid Id) : ICommand<Unit>;
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ProductID is required");
        }
    }
    public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken) ?? throw new ProductNotFoundException(command.Id);

            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
