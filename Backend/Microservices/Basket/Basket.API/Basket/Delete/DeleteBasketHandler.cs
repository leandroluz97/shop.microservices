
using Basket.API.Basket.Store;
using Basket.API.Data;
using FluentValidation;

namespace Basket.API.Basket.Delete
{
    public record DeleteBasketCommand(string Username) : ICommand<Unit>;

    public class DeleteBasketCommandValidatior : AbstractValidator<StoreBasketCommand>
    {
        public DeleteBasketCommandValidatior()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Name is required");
        }
    }
    public class DeleteBasketByUsernameHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand>
    {
        public async Task<Unit> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteBasket(command.Username, cancellationToken);
            return Unit.Value;
        }
    }
}
