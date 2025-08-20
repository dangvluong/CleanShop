using CleanShop.Application.Interfaces.Services;
using CleanShop.Domain.Common;
using CleanShop.Domain.Entities;
using CleanShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaymentEntity = CleanShop.Domain.Entities.Payment;

namespace CleanShop.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService  _currentUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateBy = _currentUserService.UserId ?? "System";
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId ?? "System";
                        entry.Entity.LastModifiedAt = DateTime.UtcNow;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
