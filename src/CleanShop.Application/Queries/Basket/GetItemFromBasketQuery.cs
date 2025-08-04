using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Queries.Basket
{
    public record GetItemFromBasketQuery(
        string BasketId,
        int ProductId
    ) : IQuery<BasketItem>;
}