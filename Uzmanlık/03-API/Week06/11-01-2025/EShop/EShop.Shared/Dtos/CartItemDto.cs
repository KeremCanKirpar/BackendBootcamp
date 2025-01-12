using System;

namespace EShop.Shared.Dtos;

public class CartItemDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int productId { get; set; }
    public ProductDto Product { get; set; } = new ProductDto();
    public int Quantity { get; set; }

    public decimal TotalPrice => Product.Price * Quantity; 
}
