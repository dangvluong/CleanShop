using CleanShop.Api.DTOs;
using CleanShop.Application.Commands.Payment;
using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IMediator sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<PaymentResult>> CreateOrUpdatePaymentIntent()
        {
            var command = new CreateOrUpdatePaymentIntentCommand(Request.Cookies["BasketId"]);
            var result = await sender.SendAsync(command);

            return result;
        }
    }
}