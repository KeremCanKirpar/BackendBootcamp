using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.Auth;

public class ForgotPasswordDto
{
    [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    public string? Email { get; set; }
}
