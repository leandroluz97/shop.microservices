﻿namespace Ordering.Application.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
        {
            return orders.Select(DtoFromOrder);
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return DtoFromOrder(order);
        }
        private static OrderDto DtoFromOrder(Order order)
        {
            return new OrderDto(
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
        }
    }
}
