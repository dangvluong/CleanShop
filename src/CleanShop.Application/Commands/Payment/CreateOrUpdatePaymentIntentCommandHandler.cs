using CleanShop.Application.Commons.Extensions;
using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Application.Queries.Basket;

namespace CleanShop.Application.Commands.Payment
{
    public class CreateOrUpdatePaymentIntentCommandHandler(
        IApplicationDbContext context,
        IPaymentService paymentService)
        : ICommandHandler<CreateOrUpdatePaymentIntentCommand, PaymentResult>
    {
        public async Task<PaymentResult> Handle(CreateOrUpdatePaymentIntentCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.BasketId == null) throw new ArgumentNullException(nameof(command.BasketId));

            var basket = await context.Baskets.GetBasketWithItemsAsync(command.BasketId);
            if (basket == null)
                return new PaymentResult
                {
                    ErrorMessage = "Basket not found"
                };

            return await paymentService.CreateOrUpdatePaymentIntent(basket);
        }
    }
}