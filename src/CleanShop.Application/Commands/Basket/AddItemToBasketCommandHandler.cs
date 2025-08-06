using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Commands.Basket
{
    public class AddItemToBasketCommandHandler : ICommandHandler<AddItemToBasketCommand, Domain.Entities.Basket>
    {
        private readonly IApplicationDbContext _context;

        public AddItemToBasketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Basket> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .ThenInclude(b => b.Product)
                .FirstOrDefaultAsync(b => b.BasketId == request.BasketId, cancellationToken);

            if (basket == null)
            {
                basket = new Domain.Entities.Basket
                {
                    BasketId = Guid.NewGuid().ToString(),
                    Items = new List<BasketItem>()
                };
                _context.Baskets.Add(basket);
            }

            var item = basket.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (item != null)
            {
                item.Quantity += request.Quantity;
            }
            else
            {
                basket.Items.Add(new BasketItem
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                });
            }

            await _context.SaveChangesAsync(cancellationToken);
            return basket;
        }
    }
}