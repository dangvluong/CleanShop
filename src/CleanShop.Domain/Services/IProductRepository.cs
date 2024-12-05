using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanShop.Domain.Entities;

namespace CleanShop.Domain.Services
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
    }
}