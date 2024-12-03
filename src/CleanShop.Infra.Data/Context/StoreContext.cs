using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infra.Data.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
