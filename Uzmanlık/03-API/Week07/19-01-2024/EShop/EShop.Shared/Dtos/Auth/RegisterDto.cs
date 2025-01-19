using System;
using System.ComponentModel.DataAnnotations;
using EShop.Shared.ComplexTypes;

namespace EShop.Shared.Dtos.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Adres alanı boş bırakılamaz.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Şehir alanı boş bırakılamaz.")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Cinsiyet alanı boş bırakılamaz.")]
    public GenderType Gender { get; set; }

    [Required(ErrorMessage = "Doğum tarihi alanı boş bırakılamaz.")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Tekrar şifre alanı boş bırakılamaz.")]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string? ConfirmPassword { get; set; }
    public string? Role { get; set; } = "User";
}
