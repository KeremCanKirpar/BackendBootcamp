using System;
using System.Text.Json.Serialization;

namespace EShop.Shared.Dtos;

public class OrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    [JsonIgnore]
    public OrderDto Order { get; set; } = new OrderDto();
    public int ProductId { get; set; }
    [JsonIgnore]
    public ProductDto Product { get; set; } = new ProductDto();
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
