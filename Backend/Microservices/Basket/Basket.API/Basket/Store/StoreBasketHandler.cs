
using Basket.API.Data;
using Discount.Grpc;
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

    public class StoreBasketHandler(IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            var basket = command.Adapt<ShoppingCart>();
            foreach (var item in basket.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest() { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
            await repository.StoreBasket(basket, cancellationToken);
            return new StoreBasketResult(basket.UserName, basket.Items, basket.TotalPrice);
        }
    }
}
