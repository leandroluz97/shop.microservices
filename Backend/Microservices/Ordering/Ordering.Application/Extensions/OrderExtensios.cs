namespace Ordering.Application.Extensions
{
    public static class OrderExtensios
    {
        public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
        {
            List<OrderDto> ordersDtos = [];
            foreach (var order in orders)
            {
                var orderDto = new OrderDto(
                    Id: order.Id.Value,
                    CustomerId: order.CustomerId.Value,
                    OrderName: order.OrderName.Value,
                    ShippingAddress: new AddressDto(
                        order.ShippingAddress.FirstName,
                        order.ShippingAddress.LastName,
                        order.ShippingAddress.EmailAddress,
                        order.ShippingAddress.AddressLine,
                        order.ShippingAddress.Country,
                        order.ShippingAddress.State,
                        order.ShippingAddress.ZipCode),
                     BillingAddress: new AddressDto(
                        order.ShippingAddress.FirstName,
                        order.ShippingAddress.LastName,
                        order.ShippingAddress.EmailAddress,
                        order.ShippingAddress.AddressLine,
                        order.ShippingAddress.Country,
                        order.ShippingAddress.State,
                        order.ShippingAddress.ZipCode),
                     Payment: new PaymentDto(
                         order.Payment.CardName,
                         order.Payment.CardNumber,
                         order.Payment.Expiration,
                         order.Payment.CVV,
                         order.Payment.PaymentMethod),
                     Status: order.Status,
                     OrderItems: order.OrderItems.Select(x => new OrderItemDto(x.ProductId.Value, order.CustomerId.Value, x.Quantity, x.Price)).ToList());

                ordersDtos.Add(orderDto);
            }

            return ordersDtos;
        }
    }
}
