using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Application.Commons.Extensions
{
    public static class BasketExtensions
    {
        public static async Task<Basket?> GetBasketWithItemsAsync(this IQueryable<Basket> query, string? basketId)
        {
            return await query
                .Include(a => a.Items)
                .ThenInclude(a => a.Product)
                .FirstOrDefaultAsync(a => a.BasketId == basketId);
        }
    }
}