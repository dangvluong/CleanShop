using CleanShop.Application.Interfaces.Messaging;

namespace CleanShop.Application.Commands.Basket
{
    public record AddItemToBasketCommand(
        string BasketId,
        int ProductId,
        int Quantity
    ) : ICommand<Domain.Entities.Basket>
    {
    }
}