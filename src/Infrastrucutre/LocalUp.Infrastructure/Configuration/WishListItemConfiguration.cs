using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class WishListItemConfiguration : BaseEntityConfiguration<WishListItem>
{
    public override void Configure(EntityTypeBuilder<WishListItem> builder)
    {
        base.Configure(builder);

        builder.ToTable("wishlist_item");

        builder.Property(i => i.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(i => i.WishListId)
            .HasColumnName("wishlist_id")
            .IsRequired();

        builder.HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.WishList)
            .WithMany(w => w.Items)
            .HasForeignKey(i => i.WishListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}