using CleanShop.Application.Commons.Interfaces;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Services;
using MediatR;

namespace CleanShop.Application.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
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
            };
            
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
