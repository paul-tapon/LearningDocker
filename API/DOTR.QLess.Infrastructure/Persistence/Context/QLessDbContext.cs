using DOTR.QLess.Application.Common.Services;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Domain.Entities;
using DOTR.QLess.Infrastructure.Persistence.Seeder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DOTR.QLess.Infrastructure.Persistence.Context
{
    public class QLessDbContext : DbContext, IQLessDbContext
    {
        private readonly ICryptographyService _cryptographyService;

        public QLessDbContext(DbContextOptions options, ICryptographyService cryptographyService) : base(options)
        {
            _cryptographyService = cryptographyService;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //ConfigureBaseInterfaceMappings(builder);
            //ConfigureManyToManyMapping(builder);
            //ConfigureOneToManyMapping(builder);

            //ConfigureOneToManyMapping(builder);

            base.OnModelCreating(builder);

            //builder.Entity<TrendGraphResult>().HasNoKey();
            //builder.Entity<ProficiencyReport1ResultDto>().HasNoKey();

            builder.Seed(_cryptographyService);

            //RegisterCustomDbFunction(builder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketNumberSeeder> TicketNumberSeeder { get; set; }

    }
}
