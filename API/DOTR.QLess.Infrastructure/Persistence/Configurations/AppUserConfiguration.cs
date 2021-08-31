using DOTR.QLess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Infrastructure.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(e => e.AppUserId);

            builder.HasOne(e => e.CreatedByAppUser)
                    .WithMany()
                    .HasForeignKey("CreatedByAppUserId")
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.LastModifiedByAppUser)
                    .WithMany()
                    .HasForeignKey("LastModifiedByAppUserId")
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(e => e.Username)
                    .IsUnique();

            builder.Property(e => e.PasswordHash).HasMaxLength(500);
            builder.Property(e => e.PasswordSalt).HasMaxLength(500);
        }
    }
}
