using System;

namespace EShop.Shared.Dtos;

public class OrderCreateDto
{
    public string? ApplicationUserId { get; set; }
    public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    public string? Address { get; set; }
    public string? City { get; set; }
    
}
