using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class BrandConfiguration : BaseEntityConfiguration<Brand>
{
    public override void Configure(EntityTypeBuilder<Brand> builder)
    {
        base.Configure(builder);

        builder.ToTable("brand");

        builder.Property(b => b.Name)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Description)
            .HasColumnName("descricao")
            .HasMaxLength(500);

        builder.HasMany(b => b.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}