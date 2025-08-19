namespace CleanShop.Domain.Entities
{
    public class Payment
    {
        public string Id { get; set; }
        public string? BasketId { get; set; }
        public string PaymentIntentId { get; set; }

        public string ClientSecret { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }

        public Basket? Basket { get; set; }

        // TODO: add audit properties 
    }
}