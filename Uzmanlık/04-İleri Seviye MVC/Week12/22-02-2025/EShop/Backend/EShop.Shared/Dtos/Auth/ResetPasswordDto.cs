using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.Auth;

public class ResetPasswordDto
{
    public string? Token { get; set; }

    [Required(ErrorMessage = "Email alanı boş bırakılamaz")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Şifre tekrarı alanı boş bırakılamaz")]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
    public string? ConfirmPassword { get; set; }
}
