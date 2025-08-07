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

        public async Task<Domain.Entities.Basket> Handle(AddItemToBasketCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

            if (product is null)
            {
                // Handle the case where the product does not exist
                // This could be throwing an exception, returning a result pattern, etc.
                throw new ArgumentException($"Product with ID {request.ProductId} does not exist.");
            }
            
            if(request.Quantity <= 0)
            {
                // Handle the case where the quantity is invalid
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            
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

            

            var existingProduct = basket.Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += request.Quantity;
            }
            else
            {
                basket.Items.Add(new BasketItem
                {
                    ProductId = product.Id,
                    Quantity = request.Quantity,
                    Product = product
                });
            }

            await _context.SaveChangesAsync(cancellationToken);
            return basket;
        }
    }
}