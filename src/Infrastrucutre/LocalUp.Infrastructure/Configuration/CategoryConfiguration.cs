using LocalUp.Domain.Entities;
using LocalUp.Infrastructure.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalUp.Infrastructure.Configuration;

public class CategoryConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("category");

        builder.Property(c => c.Name)
            .HasColumnName("nome")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Description)
            .HasColumnName("descricao")
            .HasMaxLength(500);

        builder.Property(c => c.ParentCategoryId)
            .HasColumnName("categoria_pai_id");

        builder.HasOne(c => c.ParentCategory)
            .WithMany()
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}