namespace CleanShop.Application.Commons.Models
{
    public class PaymentResult
    {
        public string PaymentId { get; set; }
        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}