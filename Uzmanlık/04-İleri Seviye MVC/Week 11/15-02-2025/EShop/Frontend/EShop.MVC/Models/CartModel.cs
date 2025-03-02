using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class CartModel
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime createDate { get; set; }

        [JsonPropertyName("updatedDate")]
        public DateTime updatedDate { get; set; }

        [JsonPropertyName("isActive")]
        public bool isActive { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool isDeleted { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string applicationUserId { get; set; } = null!;

        [JsonPropertyName("applicationUser")]
        public object applicationUser { get; set; } = null!;

        [JsonPropertyName("cartItems")]
        public List<object> cartItems { get; set; } = null!;

        [JsonPropertyName("totalAmount")]
        public decimal totalAmount { get; set; }

        [JsonPropertyName("totalItems")]
        public decimal totalItems { get; set; }
    }
}
