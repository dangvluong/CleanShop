using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanShop.Application.Interfaces.Services
{
    public interface IApplicationDbContext
    {
        DatabaseFacade Database { get; } // Add for seeding data

        DbSet<Product> Products { get; }
        
        DbSet<Domain.Entities.Basket> Baskets { get; }
        
        DbSet<Domain.Entities.Payment> Payments { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
