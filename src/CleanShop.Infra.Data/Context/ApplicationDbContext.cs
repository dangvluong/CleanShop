using CleanShop.Application.Commons.Interfaces;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // TODO: Add audit for auditable entities
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
