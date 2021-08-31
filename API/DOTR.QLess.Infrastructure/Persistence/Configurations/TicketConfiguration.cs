using DOTR.QLess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.TicketId);

            builder.HasOne(e => e.TicketType)
            .WithMany()
            .HasForeignKey("TicketTypeId")
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(e => e.TicketNumber)
                    .IsUnique();

            builder.Property(e => e.TicketNumber).HasMaxLength(20);
        }
    }
}
