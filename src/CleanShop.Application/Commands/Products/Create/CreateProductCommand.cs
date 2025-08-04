using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Commands.Products.Create
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
