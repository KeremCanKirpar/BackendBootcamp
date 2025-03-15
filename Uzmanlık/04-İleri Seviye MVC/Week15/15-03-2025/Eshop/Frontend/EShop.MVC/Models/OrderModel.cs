using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class OrderModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string? ApplicationUserId { get; set; }

        [JsonPropertyName("applicationUser")]
        public ApplicationUserModel? ApplicationUser { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemModel>? OrderItems { get; set; }

        [JsonPropertyName("totalAmount")]
        public double TotalAmount { get; set; }
    }

    public enum OrderStatus
    {
        [Display(Name = "Sipariş Alındı")]
        Pending = 0,

        [Display(Name = "Sipariş Hazırlanıyor")]
        Proccessing = 1,

        [Display(Name = "Kargoya Verildi")]
        Shipped = 2,

        [Display(Name = "Teslim Edildi")]
        Delivered = 3
    }
}
