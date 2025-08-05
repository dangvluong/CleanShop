using CleanShop.Application.Interfaces.Messaging;

namespace CleanShop.Application.Commands.Basket
{
    public record CreateBasketCommand(string BasketId) : ICommand<Domain.Entities.Basket>
    {
    }
}