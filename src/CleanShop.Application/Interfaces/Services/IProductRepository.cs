using CleanShop.Domain.Entities;

namespace CleanShop.Application.Interfaces.Services
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
    }
}