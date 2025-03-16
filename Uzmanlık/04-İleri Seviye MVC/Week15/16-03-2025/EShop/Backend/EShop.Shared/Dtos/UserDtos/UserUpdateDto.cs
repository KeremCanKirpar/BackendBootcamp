using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.UserDtos;

public class UserUpdateDto
{
    public string Id { get; set; } = null!;

    [Required(ErrorMessage = "Ad alanı zorunludur.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Soyad alanı zorunludur.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "E-posta alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    public string Email { get; set; } = null!;

    [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
    public string? PhoneNumber { get; set; }

}