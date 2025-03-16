using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class CartItemModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cartId")]
        public int CartId { get; set; }

        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("product")]
        public ProductModel Product { get; set; } = new();

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("totalPrice")]
        public decimal TotalPrice => Product.Price * Quantity;
    }
}
