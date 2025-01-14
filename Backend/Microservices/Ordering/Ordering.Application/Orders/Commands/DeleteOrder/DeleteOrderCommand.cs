using FluentValidation;

namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(Guid Id) :  ICommand<DeleteOrderResult>;
    public record DeleteOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("OrderId is required");
        }
    }

}
