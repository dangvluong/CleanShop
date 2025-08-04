using CleanShop.Application.Interfaces.Messaging;

namespace CleanShop.Application.Commands.Basket
{
    public record RemoveItemFromBasketCommand(
        string BasketId,
        int ProductId
    ) : ICommand<Domain.Entities.Basket>;
}