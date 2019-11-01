using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDATAACCES.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(g => g.Name).IsRequired()
                .HasMaxLength(40);
            builder.HasIndex(g => g.Name).IsUnique();
            builder.Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.Price).IsRequired();

            builder.HasMany(g => g.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
