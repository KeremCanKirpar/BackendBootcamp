using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class CartItemUpdateDto
{
    [Required(ErrorMessage = "Sepet Id  zorunludur.")]
    public int Id { get; set; }
    public int Quantity { get; set; }
}
