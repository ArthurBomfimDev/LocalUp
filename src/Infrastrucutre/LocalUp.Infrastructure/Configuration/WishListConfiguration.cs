using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class WishListConfiguration : BaseEntityConfiguration<WishList>
{
    public override void Configure(EntityTypeBuilder<WishList> builder)
    {
        base.Configure(builder);

        builder.ToTable("wishlist");

        builder.Property(w => w.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.HasOne(w => w.User)
            .WithMany()
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.Items)
            .WithOne(i => i.WishList)
            .HasForeignKey(i => i.WishListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}