using CleanShop.Application.Commons.Models;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaymentResult> CreateOrUpdatePaymentIntent(Basket basket);
    }
}