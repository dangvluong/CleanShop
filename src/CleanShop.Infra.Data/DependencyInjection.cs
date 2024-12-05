using CleanShop.Application.Commons.Interfaces;
using CleanShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanShop.Infra.Data
{
    public static class DependencyInjection
    {
        public static void RegisterDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("StoreDbContext")));            

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<StoreContext>());
        }
    }
}
