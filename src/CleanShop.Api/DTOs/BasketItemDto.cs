namespace CleanShop.Api.DTOs
{
    public class BasketItemDto
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string PictureUrl { get; set; }
        public required string Brand { get; set; }
        public required string Type { get; set; }
        public int Quantity { get; set; }
    }
}