using CleanShop.Application.Commands.Basket;
using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Application.Queries.Basket;
using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _sender;

        public BasketController(IApplicationDbContext context, IMediator sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket(CancellationToken cancellationToken)
        {
            // Get BasketId from the cookie
            var basketId = Request.Cookies["basketId"];


            Basket basket = null;
            
            // If the basketId exists, retrieve the basket from the database
            if (!string.IsNullOrEmpty(basketId))
            {
                // What if the basketId does not exist in the database?
                basket = await _sender.SendAsync(new GetBasketQuery(basketId), cancellationToken);
            }
            else
            {
                basketId = Guid.NewGuid().ToString();
            }

            // If the basket does not exist, create a new one
            if (basket == null)
            {
                var createCommand = new CreateBasketCommand(basketId);
                basket = await _sender.SendAsync(createCommand, cancellationToken);
            }

            // Set the basketId cookie with an expiration of 30 days
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30),
                IsEssential = true,
            };
            
            Response.Cookies.Append("basketId", basket.BasketId, cookieOptions);

            // Return the basket
            return Ok(basket);
        }
    
        [HttpPost]
        public async Task<ActionResult> AddItemToBasket(int productId, int quantity, CancellationToken cancellationToken)
        {
            // Create a command to add an item to the basket
            var basketId = Request.Cookies["basketId"];
            if(string.IsNullOrEmpty(basketId))
                basketId = Guid.NewGuid().ToString();
            
            var command = new AddItemToBasketCommand(basketId, productId, quantity);

            // Send the command using the mediator
            var result = await _sender.SendAsync(command, cancellationToken);

            // Return the updated basket
            return Created();
        }
    
        [HttpDelete]
        public async Task<ActionResult> RemoveItemFromBasket(string basketId, int productId, CancellationToken cancellationToken)
        {
            // Create a command to remove an item from the basket
            var command = new RemoveItemFromBasketCommand(basketId, productId);

            // Send the command using the mediator
            var result = await _sender.SendAsync(command, cancellationToken);

            // Check if the result is null and return NotFound if it is
            if (result == null)
                return NotFound();

            // Return the updated basket
            return NoContent();
        }
    }
}