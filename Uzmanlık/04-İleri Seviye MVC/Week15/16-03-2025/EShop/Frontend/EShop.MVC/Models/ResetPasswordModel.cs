using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Models
{
    public class ResetPasswordModel
    {
        public string? Token { get; set; }

        [Display(Name = "Kullanıcı Adı/Email")]
        [Required(ErrorMessage = "Kullanıcı Adı/Email alanı boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Geçersiz email")]
        public string? Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        public string? NewPassword { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Şifre tekrarı alanı boş bırakılamaz")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        public string? ConfirmNewPassword { get; set; }
    }
}
