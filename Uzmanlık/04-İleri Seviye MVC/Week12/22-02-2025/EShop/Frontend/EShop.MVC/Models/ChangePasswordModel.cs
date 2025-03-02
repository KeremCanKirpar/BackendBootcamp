using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Models
{
    public class ChangePasswordModel
    {
        [Display(Name ="Kullanıcı Adı/Email")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string? UserName { get; set; }


        [Display(Name="Geçerli Şifre")]
        [Required(ErrorMessage = "Mevcut şifre boş bırakılamaz")]
        public string? CurrentPassword { get; set; }

        [Display(Name ="Yeni Şifre")]
        [Required(ErrorMessage = "Yeni şifre boş bırakılamaz")]
        public string? NewPassword { get; set; }

        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Yeni şifre tekrarı boş bırakılamaz")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        public string? ConfirmPassword { get; set; }
    }
}
