namespace CleanShop.Application.Commons.Models
{
    public class SearchProductParams
    {
        public string? OrderBy { get; set; }
        public string? SearchValue { get; set; }
        public string? Brands { get; set; }
        public string? Types { get; set; }
    }
}