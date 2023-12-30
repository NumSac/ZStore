using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZStore.Infrastructure.Identity;
using ZStore.Infrastructure.Repository.IRepository;
using ZStore.Infrastructure.Repository;
using ZStore.Infrastructure.DbInitializer;

namespace ZStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DevelopmentConnection");

            Guard.Against.Null(connectionString, message: "Connection string 'Database' not found");

            services.AddScoped<IDbInitializer, DbInitializer.DbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IIdentityService, IdentityService>();


            return services;
        }
    }
}
