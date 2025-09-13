using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("user");

        builder.Property(u => u.Name)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.PasswordHash)
            .HasColumnName("senha_hash")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Role)
            .HasColumnName("role")
            .IsRequired();

        builder.Property(u => u.Phone)
            .IsRequired()
            .HasMaxLength(15);

        builder.HasMany(u => u.Addresses)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}