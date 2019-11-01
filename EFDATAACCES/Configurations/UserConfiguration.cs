using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDATAACCES.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).IsRequired()
                 .HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired()
                 .HasMaxLength(30);
            builder.Property(u => u.Username).IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

        }
    }
}
