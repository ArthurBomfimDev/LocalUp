using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
{
    public override void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        base.Configure(builder);

        builder.ToTable("order_item");

        builder.Property(oi => oi.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(oi => oi.Quantity)
            .HasColumnName("quantidade")
            .IsRequired();

        builder.Property(oi => oi.UnitPrice)
            .HasColumnName("preco_unitario")
            .IsRequired();

        builder.Property(oi => oi.OrderId)
            .HasColumnName("order_id")
            .IsRequired();

        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}