using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.Shared.Dtos.AuthDtos
{
    public class ChangePasswordDto
    {
        [JsonIgnore]
        public string? ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Mevcut şifre boş bırakılamaz")]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre boş bırakılamaz")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre tekrarı boş bırakılamaz")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        public string? ConfirmNewPassword { get; set; }
    }
}
