using CleanShop.Domain.Entities;

namespace CleanShop.Application.Interfaces.Services.DataAccess
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
    }
}