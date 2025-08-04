using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Commands.Basket
{
    public class RemoveItemFromBasketCommandHandler : ICommandHandler<RemoveItemFromBasketCommand, Domain.Entities.Basket>
    {
        private readonly IApplicationDbContext _context;

        public RemoveItemFromBasketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Basket> Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.BasketId == request.BasketId, cancellationToken);

            if (basket == null)
                return null;

            var item = basket.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item != null)
            {
                basket.Items.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return basket;
        }
    }
}