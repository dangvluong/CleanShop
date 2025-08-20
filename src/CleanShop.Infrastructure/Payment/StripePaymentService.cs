using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace CleanShop.Infrastructure.Payment
{
    public class StripePaymentService(IConfiguration configuration, IApplicationDbContext context) : IPaymentService
    {
        public async Task<PaymentResult> CreateOrUpdatePaymentIntent(Basket basket)
        {
            StripeConfiguration.ApiKey = configuration["StripeSettings:SecretKey"];

            var service = new PaymentIntentService();

            PaymentIntent intent;
            var subTotal = basket.Items.Sum(a => a.Quantity * a.Product.Price);
            var deliveryFee = subTotal > 10000 ? 0 : 500;

            // Check if a payment already exists for this basket
            var payment = await context.Payments.FirstOrDefaultAsync(a => a.BasketId == basket.BasketId);

            if (payment == null || string.IsNullOrEmpty(payment.PaymentIntentId))
            {
                // Create new payment intent
                var options = new PaymentIntentCreateOptions
                {
                    Amount = subTotal + deliveryFee,
                    Currency = "usd",
                    PaymentMethodTypes = ["card"]
                };
                intent = await service.CreateAsync(options);

                // Create new Payment entity
                payment = new Domain.Entities.Payment
                {
                    Id = Guid.NewGuid().ToString(),
                    BasketId = basket.BasketId,
                    PaymentIntentId = intent.Id,
                    Amount = subTotal + deliveryFee,
                    Currency = intent.Currency,
                    Status = intent.Status,
                    ClientSecret = intent.ClientSecret
                };
                
                await context.Payments.AddAsync(payment);
            }
            else
            {
                // Update existing payment intent
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = subTotal + deliveryFee,
                };

                intent = await service.UpdateAsync(payment.PaymentIntentId, options);

                // Update Payment entity
                payment.Amount = subTotal + deliveryFee;
            }

            // Update the payment in db
            await context.SaveChangesAsync();

            return new PaymentResult
            {
                PaymentId = payment.Id,
                PaymentIntentId = intent.Id,
                ClientSecret = intent.ClientSecret,
                Amount = payment.Amount,
                Currency = payment.Currency,
                Status = payment.Status,
                Success = true // TODO check status of payment 
            };
        }
    }
}