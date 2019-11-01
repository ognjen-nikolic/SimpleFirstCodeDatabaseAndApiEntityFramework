using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDATAACCES.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).IsRequired()
                .HasMaxLength(30);
            builder.HasIndex(g => g.Name).IsUnique();
            builder.Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
