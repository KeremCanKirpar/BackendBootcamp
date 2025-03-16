using System;
using System.Text.Json.Serialization;
using System.Linq;

namespace EShop.MVC.Models
{
    public class CartModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string? ApplicationUserId { get; set; }

        [JsonPropertyName("cartItems")]
        public List<CartItemModel> CartItems { get; set; } = new();

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount => CartItems.Sum(x => x.Product.Price * x.Quantity);

        [JsonPropertyName("totalItems")]
        public int TotalItems => CartItems?.Count ?? 0;
    }
}
