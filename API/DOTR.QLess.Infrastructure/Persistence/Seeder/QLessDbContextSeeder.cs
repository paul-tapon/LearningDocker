using DOTR.QLess.Application.Common.Services;
using DOTR.QLess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Infrastructure.Persistence.Seeder
{
    public static class QLessDbContextSeeder
    {
        public static void Seed(this ModelBuilder builder, ICryptographyService cryptographyService)
        {
            AddDefaultUser(builder, cryptographyService);
            AddTicketType(builder);
        }

        private static void AddDefaultUser(ModelBuilder builder, ICryptographyService cryptographyService)
        {
            var appUserGuid = Guid.Parse("8F563B98-6F6B-4579-B386-B8096B0ADBBD"); 
            string appUserName = "sys.default";


            string defaultPassword = "P@ssw0rd2021";
            string passwordSalt = string.Empty;
            var passwordHashed = cryptographyService.GenerateHashedPasswordWithSalt(defaultPassword, ref passwordSalt);

            var appUser = new AppUser
            {
                AppUserId = 1,
                Username = appUserName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHashed,
                CustomerUniqueId = appUserGuid,
                IsActive = true,
                CreatedDate = DateTime.Now,
            };

            builder.Entity<AppUser>().HasData(appUser);
        }

        private static void AddTicketType(ModelBuilder builder)
        {
            var regularType = new TicketType 
            {
                TicketTypeId = 1,
                Name = "Regular",
                FixRate = 15,
                InitialLoad = 100,
                CreatedByAppUserId=1,
                CreatedDate=DateTime.Now,
                IsActive = true
            };

            var discountedType = new TicketType
            {
                TicketTypeId = 2,
                Name = "Discounted",
                FixRate = 10,
                InitialLoad = 500,
                CreatedByAppUserId = 1,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            builder.Entity<TicketType>().HasData(regularType);
            builder.Entity<TicketType>().HasData(discountedType);

        }
    }
}
