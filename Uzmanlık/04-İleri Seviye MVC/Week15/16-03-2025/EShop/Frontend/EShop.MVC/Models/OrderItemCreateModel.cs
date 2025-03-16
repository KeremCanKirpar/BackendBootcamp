using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class OrderItemCreateModel
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonIgnore]
        public string? ProductName { get; set; }

        [JsonIgnore]
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
