using CleanShop.Application.Commons.Interfaces;
using CleanShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Products.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
