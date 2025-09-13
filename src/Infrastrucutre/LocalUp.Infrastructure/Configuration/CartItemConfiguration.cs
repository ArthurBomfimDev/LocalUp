using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class CartItemConfiguration : BaseEntityConfiguration<CartItem>
{
    public override void Configure(EntityTypeBuilder<CartItem> builder)
    {
        base.Configure(builder);

        builder.ToTable("cart_item");

        builder.Property(ci => ci.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(ci => ci.Quantity)
            .HasColumnName("quantidade")
            .IsRequired();

        builder.Property(ci => ci.UnitPrice)
            .HasColumnName("preco_unitario")
            .IsRequired();

        builder.Property(ci => ci.CartId)
            .HasColumnName("cart_id")
            .IsRequired();

        builder.HasOne(ci => ci.Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}