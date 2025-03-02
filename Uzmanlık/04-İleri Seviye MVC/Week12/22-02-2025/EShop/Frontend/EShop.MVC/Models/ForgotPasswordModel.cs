using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Models
{
    public class ForgotPasswordModel
    {
        [Display(Name = "Kayıtlı Email Adresi")]
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string? Email { get; set; }
    }
}
