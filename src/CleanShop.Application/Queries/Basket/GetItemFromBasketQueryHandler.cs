using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Queries.Basket
{
    public class GetItemFromBasketQueryHandler : IQueryHandler<GetItemFromBasketQuery, BasketItem>
    {
        private readonly IApplicationDbContext _context;

        public GetItemFromBasketQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BasketItem?> Handle(GetItemFromBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BasketId == request.BasketId, cancellationToken);

            return basket?.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
        }
    }
}