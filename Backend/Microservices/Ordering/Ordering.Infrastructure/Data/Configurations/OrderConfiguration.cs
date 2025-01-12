using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(
                    id => id.Value,
                    id => OrderId.Of(id));

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId);

            builder.HasMany(x => x.OrderItems)
               .WithOne()
               .HasForeignKey(x => x.OrderId);

            builder.ComplexProperty(
                x => x.OrderName,
                nameBuilder =>
                {
                    nameBuilder.Property(x => x.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
                });

            builder.ComplexProperty(x => x.ShippingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.EmailAddress)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180);

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

            builder.ComplexProperty(x => x.BillingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.EmailAddress)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180);

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

            builder.ComplexProperty(x => x.Payment, addressBuilder =>
            {
                addressBuilder.Property(a => a.CardName)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.CardNumber)
                   .HasMaxLength(25)
                   .IsRequired();

                addressBuilder.Property(a => a.Expiration)
                   .HasMaxLength(10);

                addressBuilder.Property(a => a.CVV)
                    .HasMaxLength(3);

                addressBuilder.Property(a => a.PaymentMethod);

            });

            builder.Property(x => x.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion( x => x.ToString(), status => (OrderStatus)Enum.Parse(typeof(OrderStatus), status));

            builder.Property(x => x.TotalPrice);
        }
    }
}
