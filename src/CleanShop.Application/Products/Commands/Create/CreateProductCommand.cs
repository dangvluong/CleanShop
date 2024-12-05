using CleanShop.Domain.Entities;
using MediatR;

namespace CleanShop.Application.Products.Commands.Create
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        string ImageUrl,
        string Type,
        string Brand) : IRequest<Product>
    {

    }
}
