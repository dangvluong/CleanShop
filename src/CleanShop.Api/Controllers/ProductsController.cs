using CleanShop.Api.DTOs;
using CleanShop.Api.Extensions;
using CleanShop.Application.Commands.Products.Create;
using CleanShop.Application.Commons.Models;
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
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]SearchProductParams searchProductParams, [FromQuery] PaginationParams paginationParams,CancellationToken cancellationToken = default)
        {
            var query = new GetProductsQuery
            {
                SearchParams = searchProductParams,
                PaginationParams = paginationParams
            };

            var products = await _sender.SendAsync(query, cancellationToken);
            Response.AddPaginationHeader(products.Metadata);

            return Ok(products);
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

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters(CancellationToken cancellationToken = default)
        {
            var command = new GetProductFilterOptionsQuery();
            
            var filters = await _sender.SendAsync(command, cancellationToken);
            
            return  Ok(filters);
        }
    }
}