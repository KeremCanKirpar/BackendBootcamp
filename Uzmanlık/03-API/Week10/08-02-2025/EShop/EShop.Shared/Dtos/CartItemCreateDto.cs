using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class CartItemCreateDto
{
    [Required(ErrorMessage = "Sepet Id zorunludur.")]
    public int CartId { get; set; }

    [Required(ErrorMessage = "Ürün Id zorunludur.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Ürün miktarı zorunludur.")]
    public int Quantity { get; set; }
}
