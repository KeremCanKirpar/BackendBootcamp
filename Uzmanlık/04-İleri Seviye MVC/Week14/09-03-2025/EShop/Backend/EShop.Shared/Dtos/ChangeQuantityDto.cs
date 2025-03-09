using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class ChangeQuantityDto
{
    [Required(ErrorMessage = "Sepet item id'si zorunludur.")]
    public int CartItemId { get; set; }

    [Required(ErrorMessage = "Ürün miktarı zorunludur.")]
    public int Quantity { get; set; }
}
