using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Queries.Products
{
    public record GetProductByIdQuery(int productId) : IQuery<Product>;
}
