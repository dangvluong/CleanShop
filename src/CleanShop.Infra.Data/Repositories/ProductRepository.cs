using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanShop.Domain.Entities;
using CleanShop.Domain.Services;
using CleanShop.Infra.Data.Context;

namespace CleanShop.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task AddProduct(Product product)
        {
            // TODO add validation
            _storeContext.Products.Add(product);
            await _storeContext.SaveChangesAsync();
        }
    }
}