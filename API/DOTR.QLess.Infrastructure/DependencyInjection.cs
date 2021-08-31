using DOTR.QLess.Application.Common.Services;
using DOTR.QLess.Application.Context;
using DOTR.QLess.Infrastructure.Persistence.Context;
using DOTR.QLess.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Infrastructure
{
    public static class DependencyInjection
    {
        public static readonly ILoggerFactory SqlDebugLogger
       = LoggerFactory.Create(builder => { builder.AddDebug(); });
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {

            services.AddDbContext<QLessDbContext>(options =>
                options.UseLoggerFactory(SqlDebugLogger).UseSqlServer(
                    configuration.GetConnectionString("QLessDbContext"),
                    b => b.MigrationsAssembly(typeof(QLessDbContext).Assembly.FullName)));

            services.AddScoped<IQLessDbContext>(provider => provider.GetService<QLessDbContext>());
      


            services.AddTransient<IDateTimeService, DatetimeService>();
            services.AddTransient<ICryptographyService, CryptographyService>();
            //services.AddTransient<IEmailService, EmailService>();


            return services;
        }
    }
}
