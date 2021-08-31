using DOTR.QLess.Domain.Entities;
using DOTR.QLess.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOTR.QLess.Application.Context
{
    public interface IQLessDbContext
    {
        DbSet<DOTR.QLess.Domain.Entities.TicketType> TicketTypes { get; set; }
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<DOTR.QLess.Domain.Entities.Ticket> Tickets { get; set; }
        DbSet<DOTR.QLess.Domain.Entities.TicketNumberSeeder> TicketNumberSeeder { get; set; }
        Task<int> SaveChangesAsync();
    }
}
