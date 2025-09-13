using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class UserAddressConfiguration : BaseEntityConfiguration<UserAddress>
{
    public override void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        base.Configure(builder);

        builder.ToTable("user_address");

        builder.Property(a => a.Street)
            .HasColumnName("rua")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.City)
            .HasColumnName("cidade")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.State)
            .HasColumnName("estado")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Country)
            .HasColumnName("pais")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.PostalCode)
            .HasColumnName("codigo_postal")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(a => a.Complement)
            .HasColumnName("complemento")
            .HasMaxLength(100);

        builder.Property(a => a.Number)
            .HasColumnName("numero")
            .IsRequired();

        builder.Property<long>("UserId")
            .HasColumnName("user_id");
    }
}