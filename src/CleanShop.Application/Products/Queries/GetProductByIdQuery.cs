using CleanShop.Domain.Entities;
using MediatR;

namespace CleanShop.Application.Products.Queries
{
    public record GetProductByIdQuery(int productId) : IRequest<Product>;
}
