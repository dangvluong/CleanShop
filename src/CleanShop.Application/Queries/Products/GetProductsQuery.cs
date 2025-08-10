using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Queries.Products
{
    public record GetProductsQuery : IQuery<IEnumerable<Product>>
    {
        public string OrderBy { get; set; }
        public string SearchValue { get; set; }
        public string Brands { get; set; }
        public string Types { get; set; }
    };
}