using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [JsonPropertyName("userNameOrEmail")]
        public string UserNameOrEmail { get; set; } = null!;

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla")]
        [JsonPropertyName("rememberMe")]
        public bool RememberMe { get; set; }
    }
}
