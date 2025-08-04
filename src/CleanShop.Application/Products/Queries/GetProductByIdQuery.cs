using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Products.Queries
{
    public record GetProductByIdQuery(int productId) : IQuery<Product>;
}
