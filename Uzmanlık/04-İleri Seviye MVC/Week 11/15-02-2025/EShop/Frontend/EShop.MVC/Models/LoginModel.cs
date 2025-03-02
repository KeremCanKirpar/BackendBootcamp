using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class LoginModel
    {   
        [Display(Name = "Kullanıcı Adı veya Email:")]
        [Required(ErrorMessage ="Kullanıcı Adı veya Email boş bırakılamaz!")]
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = null!;
        [Display(Name ="Şifre:")]
        [Required(ErrorMessage ="Şifre boş bırakılamaz!")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}
