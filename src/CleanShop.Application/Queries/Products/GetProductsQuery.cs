using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Domain.Entities;

namespace CleanShop.Application.Queries.Products
{
    public record GetProductsQuery : IQuery<PagedList<Product>>
    {
        public SearchProductParams SearchParams { get; set; }
        public PaginationParams PaginationParams { get; set; }
    };
}