using DOTR.QLess.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Infrastructure.Persistence.Configurations.Common
{
    public class AuditableEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
where TEntity : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasOne(x => x.CreatedByAppUser).WithMany().HasForeignKey("CreatedByAppUserId").OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.LastModifiedByAppUser)
                    .WithMany()
                    .HasForeignKey("LastModifiedByAppUserId")
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
