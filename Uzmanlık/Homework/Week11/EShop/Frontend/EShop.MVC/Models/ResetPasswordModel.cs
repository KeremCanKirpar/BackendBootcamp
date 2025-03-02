using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Models
{
    public class ResetPasswordModel
    {
        public string? Token { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string? Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        public string? Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Şifre tekrarı alanı boş bırakılamaz")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string? ConfirmPassword { get; set; }
    }
}
