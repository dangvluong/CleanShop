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
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(b => b.BasketId == request.BasketId, cancellationToken);

            if (basket == null)
                // Result pattern?
                return null;

            var item = basket.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item != null)
            {
                if (item.Quantity > request.Quantity)
                {
                    item.Quantity -= request.Quantity;
                }
                else
                {
                    // If the quantity to remove is greater than or equal to the current quantity, remove the item entirely
                    basket.Items.Remove(item);
                }
                var result = await _context.SaveChangesAsync(cancellationToken);
            }

            return basket;
        }
    }
}