
using Basket.API.Basket.Store;
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
    public class DeleteBasketByUsernameHandler : ICommandHandler<DeleteBasketCommand>
    {
        public Task<Unit> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
