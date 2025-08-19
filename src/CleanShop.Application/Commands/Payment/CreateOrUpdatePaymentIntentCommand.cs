using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces.Messaging;

namespace CleanShop.Application.Commands.Payment
{
    public record CreateOrUpdatePaymentIntentCommand(string BasketId)
        : ICommand<PaymentResult>;
}