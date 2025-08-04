using CleanShop.Application.Commands.Products.Create;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Queries.Products;
using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _sender;

        public ProductsController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery();

            var result = await _sender.SendAsync(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(productId);

            var result = await _sender.SendAsync(query, cancellationToken);
            if (result == null) return NotFound();

            return Ok(result);
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

            var result = await _sender.SendAsync(command, cancellationToken);

            return Ok(result);
        }
    }
}