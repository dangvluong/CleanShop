using CleanShop.Application.Commons.Models;
using CleanShop.Application.Interfaces;
using CleanShop.Application.Interfaces.Messaging;
using CleanShop.Application.Interfaces.Services;
using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Queries.Products
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PagedList<Product>>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Product>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Products.AsQueryable();
            query = request.SearchParams.OrderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };

            if (!string.IsNullOrEmpty(request.SearchParams.SearchTerm))
            {
                var lowerCaseSearchTerm = request.SearchParams.SearchTerm.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
            }

            var brandList = new List<string>();
            var typeList = new List<string>();
            
            if (!string.IsNullOrEmpty(request.SearchParams.Types))
            {
                typeList.AddRange([..request.SearchParams.Types.ToLower().Split(",")]);
            }
            
            if (!string.IsNullOrEmpty(request.SearchParams.Brands))
            {
                brandList.AddRange([..request.SearchParams.Brands.ToLower().Split(",")]);
            }
            
            query = query.Where(a => brandList.Count == 0 || brandList.Contains(a.Brand.ToLower()))
                .Where(a => typeList.Count == 0 || typeList.Contains(a.Type.ToLower()));
            
            var products = await PagedList<Product>.ToPagedList(query, request.PaginationParams.PageNumber, request.PaginationParams.PageSize);

            return products;
        }
    }
}