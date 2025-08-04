using CleanShop.Application.Commands.Basket;
using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Application.Queries.Basket;
using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Api.Controllers;

public class BasketController : ControllerBase
{
    private readonly IMediator _sender;

    public BasketController(IApplicationDbContext context, IMediator sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<Basket>> GetBasket(string basketId, CancellationToken cancellationToken)
    {
        // Create a query to get the basket
        var query = new GetBasketQuery(basketId);

        // Send the query using the mediator
        var result = await _sender.SendAsync(query, cancellationToken);

        // Check if the result is null and return NotFound if it is
        if (result == null)
            return NotFound();

        // Return the basket
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult> AddItemToBasket(string basketId, int productId, int quantity, CancellationToken cancellationToken)
    {
        // Create a command to add an item to the basket
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