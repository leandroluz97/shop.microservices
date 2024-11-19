
using FluentValidation;

namespace Basket.API.Basket.Store
{
    public record StoreBasketCommand(string UserName, List<ShoppingCartItem> Items) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName, List<ShoppingCartItem> Items, decimal TotalPrice);
    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Items).NotEmpty().NotNull().WithMessage("Cart is required");
        }
    }

    public class StoreBasketHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
