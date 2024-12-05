using CleanShop.Domain.Entities;
using MediatR;

namespace CleanShop.Application.Products.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
