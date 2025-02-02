using System;
using EShop.Shared.ComplexTypes;

namespace EShop.Shared.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? ApplicationUserId { get; set; }
    public ApplicationUserDto ApplicationUser { get; set; } = new ApplicationUserDto();
    public string? Address { get; set; }
    public string? City { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    public decimal TotalAmount => OrderItems.Sum(x => x.TotalPrice);
}
