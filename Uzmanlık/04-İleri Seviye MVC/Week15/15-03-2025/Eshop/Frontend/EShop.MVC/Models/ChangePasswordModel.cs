using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Mevcut şifre alanı zorunludur.")]
        [Display(Name = "Mevcut Şifre")]
        [DataType(DataType.Password)]
        [JsonPropertyName("currentPassword")]
        public string CurrentPassword { get; set; } = null!;

        [Required(ErrorMessage = "Yeni şifre alanı zorunludur.")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [JsonPropertyName("newPassword")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = "Yeni şifre tekrarı zorunludur.")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler uyuşmuyor.")]
        [JsonPropertyName("confirmNewPassword")]
        public string ConfirmNewPassword { get; set; } = null!;
    }
}
