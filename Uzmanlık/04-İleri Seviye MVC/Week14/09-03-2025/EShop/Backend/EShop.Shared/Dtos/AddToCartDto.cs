using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.Shared.Dtos;

public class AddToCartDto
{
    [JsonIgnore]
    public string? ApplicationUserId { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Ürün id zorunludur.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Ürün miktarı zorunludur.")]
    public int Quantity { get; set; }
}
