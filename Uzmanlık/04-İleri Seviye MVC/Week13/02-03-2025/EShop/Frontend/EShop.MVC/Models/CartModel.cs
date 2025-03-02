using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class CartModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; } = null!;

        [JsonPropertyName("applicationUser")]
        public object ApplicationUser { get; set; } = null!;

        [JsonPropertyName("cartItems")]
        public List<object> CartItems { get; set; } = [];

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("totalItems")]
        public decimal TotalItems { get; set; }
    }

}
