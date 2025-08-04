using CleanShop.Application.Interfaces.Messaging;

namespace CleanShop.Application.Queries.Basket
{
    public record GetBasketQuery(string BasketId) : IQuery<Domain.Entities.Basket>;
}