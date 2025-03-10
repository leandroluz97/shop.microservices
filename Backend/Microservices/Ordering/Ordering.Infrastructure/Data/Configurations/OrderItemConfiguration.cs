﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(
                    id => id.Value,
                    id => OrderItemId.Of(id));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            builder.Property(x => x.Quantity)
                .IsRequired();
            
            builder.Property(x => x.Price)
                .IsRequired();

        }
    }
}
