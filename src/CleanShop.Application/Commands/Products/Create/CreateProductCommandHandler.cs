using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Commands.Products.Create
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Product>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // TODO use automapper
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Brand = request.Brand,
                Type = request.Type,
                ImageUrl = request.ImageUrl
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
