using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Queries.Basket
{
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, Domain.Entities.Basket>
    {
        private readonly IApplicationDbContext _context;

        public GetBasketQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Basket?> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return await _context.Baskets
                .Include(b => b.Items)
                .ThenInclude(a => a.Product)
                .FirstOrDefaultAsync(b => b.BasketId == request.BasketId, cancellationToken);
        }
    }
}