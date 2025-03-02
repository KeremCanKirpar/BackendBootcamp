using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class OrderModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; } = null!;

        [JsonPropertyName("applicationUser")]
        public object ApplicationUser { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("city")]
        public string City { get; set; } = null!;

        [JsonPropertyName("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemModel> OrderItems { get; set; } = [];

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
    }

    public enum OrderStatus
    {
        Pending = 0,
        Proccessing = 1,
        Shipped = 2,
        Delivered = 3
    }
}
