using CleanShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanShop.Infra.Data
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("StoreDbContext")));
            services.AddScoped<StoreContext>();

            return services;
        }
    }
}
