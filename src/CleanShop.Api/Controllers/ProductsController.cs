using CleanShop.Application.Commons.Interfaces.Messaging;
using CleanShop.Application.Products.Commands.Create;
using CleanShop.Application.Products.Queries;
using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetProducts(IQueryHandler<GetProductsQuery, IEnumerable<Product>> handler, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery();

            var result = await handler.Handle(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId,IQueryHandler<GetProductByIdQuery, Product> handler, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(productId);

            var result = await handler.Handle(query, cancellationToken);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product,ICommandHandler<CreateProductCommand,Product> handler, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand(product.Name,
                                                   product.Description,
                                                   product.Price,
                                                   product.ImageUrl,
                                                   product.Type,
                                                   product.Brand);

            var result = await handler.Handle(command, cancellationToken);

            return Ok(result);
        }
    }
}
