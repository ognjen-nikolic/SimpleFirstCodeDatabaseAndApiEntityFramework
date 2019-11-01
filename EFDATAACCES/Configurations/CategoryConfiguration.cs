using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDATAACCES.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired()
                 .HasMaxLength(30);
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasMany(c => c.ProductCategories)
                .WithOne(cp => cp.Category)
                .HasForeignKey(cp => cp.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
