using CleanShop.Application.Commons.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Products.Commands.Create
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        string ImageUrl,
        string Type,
        string Brand) : ICommand<Product>
    {

    }
}
