using CleanShop.Application.Commons.Interfaces;
using CleanShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(a => a.Id == request.productId, cancellationToken);
        }
    }
}
