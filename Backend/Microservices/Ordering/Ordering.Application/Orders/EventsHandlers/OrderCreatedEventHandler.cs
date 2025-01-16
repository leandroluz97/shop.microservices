

namespace Ordering.Application.Orders.EventsHandlers
{
    public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger) :
        INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event Handled: {DomainEvent}", notification.GetType());
            return Task.CompletedTask;
        }
    }
}
