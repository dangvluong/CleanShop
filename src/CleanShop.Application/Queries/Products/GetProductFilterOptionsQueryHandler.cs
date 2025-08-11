using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Queries.Products
{
    public class GetProductFilterOptionsQueryHandler :  IQueryHandler<GetProductFilterOptionsQuery, ProductFilterOptions>
    {
        private readonly IApplicationDbContext _context;

        public GetProductFilterOptionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductFilterOptions> Handle(GetProductFilterOptionsQuery query, CancellationToken cancellationToken = default)
        {
            var brands = await _context.Products.Select(a => a.Brand).Distinct().ToListAsync(cancellationToken: cancellationToken);
            var types = await _context.Products.Select(a => a.Type).Distinct().ToListAsync(cancellationToken: cancellationToken);

            return new ProductFilterOptions
            {
                Brands = brands,
                Types = types
            };
        }
    }
}