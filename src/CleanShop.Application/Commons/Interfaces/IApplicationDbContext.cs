using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CleanShop.Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {
        DatabaseFacade Database { get; } // Add for seeding data

        DbSet<Product> Products { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
