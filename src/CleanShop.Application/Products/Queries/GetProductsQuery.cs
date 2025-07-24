using CleanShop.Application.Commons.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Products.Queries
{
    public record GetProductsQuery : IQuery<IEnumerable<Product>>;
}
