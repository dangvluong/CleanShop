using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Commands.Basket
{
    public class CreateBasketCommandHandler  : ICommandHandler<CreateBasketCommand, Domain.Entities.Basket>
    {
        private readonly IApplicationDbContext _context;

        public CreateBasketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Basket> Handle(CreateBasketCommand command, CancellationToken cancellationToken = default)
        {
            var basket = new Domain.Entities.Basket
            {
                BasketId = command.BasketId,
                Items = new List<BasketItem>()
            };
            _context.Baskets.Add(basket);
            var result =  await _context.SaveChangesAsync(cancellationToken);
            if(result > 0) return basket;
            
            // Result pattern?
            else return null;
        }
    }
}