namespace Ordering.Application.Dtos
{
    public record OrderItemDto(Guid ProductId, Guid CustomerId, int Quantity, decimal Price);

}
