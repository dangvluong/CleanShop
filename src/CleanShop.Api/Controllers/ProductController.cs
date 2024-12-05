using CleanShop.Application.Products.Commands.Create;
using CleanShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand(product.Name,
                                                   product.Description,
                                                   product.Price,
                                                   product.ImageUrl,
                                                   product.Type,
                                                   product.Brand);

            var result = await _sender.Send(command,cancellationToken);
            
            return Ok(result);
        }
    }
}
