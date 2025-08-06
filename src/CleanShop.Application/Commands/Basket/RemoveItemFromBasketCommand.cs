using CleanShop.Application.Interfaces.Messaging;

namespace CleanShop.Application.Commands.Basket
{
    public record RemoveItemFromBasketCommand(
        string BasketId,
        int ProductId,
        int Quantity
    ) : ICommand<Domain.Entities.Basket>;
}