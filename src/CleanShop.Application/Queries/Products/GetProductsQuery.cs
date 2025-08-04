using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Queries.Products
{
    public record GetProductsQuery : IQuery<IEnumerable<Product>>;
}
