using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ZStore.Infrastructure.Data;
using ZStore.Infrastructure.Identity;

namespace ZStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DevelopmentConnection");

            Guard.Against.Null(connectionString, message: "Connection string 'Database' not found");
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
