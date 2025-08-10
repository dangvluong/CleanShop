namespace CleanShop.Api.DTOs
{
    public class GetProductRequest
    {
        public string? OrderBy { get; set; }
        public string? SearchValue { get; set; }
        public string? Brands { get; set; }
        public string? Types { get; set; }
    }
}