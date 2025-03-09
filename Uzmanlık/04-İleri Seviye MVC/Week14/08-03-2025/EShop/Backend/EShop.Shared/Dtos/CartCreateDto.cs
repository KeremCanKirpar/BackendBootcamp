using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos;

public class CartCreateDto
{
    [Required(ErrorMessage = "Kullanıcı Id zorunludur.")]
    public string? ApplicationUserId { get; set; }
}
