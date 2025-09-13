using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class ProductConfiguration : BaseEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.ToTable("product");

        builder.Property(p => p.Title)
            .HasColumnName("titulo")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasColumnName("descricao")
            .HasMaxLength(1000);

        builder.Property(p => p.Price)
            .HasColumnName("preco")
            .IsRequired();

        builder.Property(p => p.DiscountPercent)
            .HasColumnName("desconto")
            .IsRequired();

        builder.Property(p => p.WeightKg)
            .HasColumnName("peso_kg")
            .IsRequired();

        builder.Property(p => p.HeightCm)
            .HasColumnName("altura_cm")
            .IsRequired();

        builder.Property(p => p.WidthCm)
            .HasColumnName("largura_cm")
            .IsRequired();

        builder.Property(p => p.DepthCm)
            .HasColumnName("profundidade_cm")
            .IsRequired();

        builder.Property(p => p.Stock)
            .HasColumnName("estoque")
            .IsRequired();

        builder.Property(p => p.CategoryId)
            .HasColumnName("categoria_id")
            .IsRequired();

        builder.Property(p => p.BrandId)
            .HasColumnName("marca_id")
            .IsRequired();
    }
}