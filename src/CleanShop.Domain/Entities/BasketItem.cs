using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace CleanShop.Domain.Entities;

public class BasketItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    // Navigation properties
    public int ProductId { get; set; }
    public Product Product { get; set; }

    // [JsonIgnore]
    // public int BasketId { get; set; }
    // public Basket Basket { get; set; }
}