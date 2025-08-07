using CleanShop.Api.DTOs;
using CleanShop.Domain.Entities;

namespace CleanShop.Api.Extensions
{
    public static class BasketExtensions
    {
        public static BasketDto ToDto(this Basket basket)
        {
            return new BasketDto
            {
                BasketId = basket.BasketId,
                Items = basket.Items.Select(i => new BasketItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Name = i.Product.Name,
                    Price = i.Product.Price,
                    PictureUrl = i.Product.ImageUrl,
                    Brand = i.Product.Brand,
                    Type = i.Product.Type
                }).ToList()
            };
        }
    }
}