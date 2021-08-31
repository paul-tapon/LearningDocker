using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace DOTR.QLess.Api.Extensions
{
    public static class CORSDependencyExtension
    {
        public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration, string mtrsCorsPolicyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(mtrsCorsPolicyName,
                builder =>
                {
                    builder.WithOrigins(configuration["AllowedHosts"]).AllowAnyHeader().AllowAnyMethod()
                    .WithExposedHeaders("X-Pagination", "Location"); ;
                });
            });

            return services;
        }
    }
}
