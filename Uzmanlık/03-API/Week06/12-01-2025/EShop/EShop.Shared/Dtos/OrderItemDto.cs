using System;

namespace EShop.Shared.Dtos;

public class OrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public OrderDto Order { get; set; }=new OrderDto();
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }=new ProductDto();
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
