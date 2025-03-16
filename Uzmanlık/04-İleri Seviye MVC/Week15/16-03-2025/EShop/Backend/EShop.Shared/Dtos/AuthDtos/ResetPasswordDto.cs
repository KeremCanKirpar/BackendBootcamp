using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.AuthDtos
{
    public class ResetPasswordDto
    {
        public string? Token { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı alanı boş bırakılamaz")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        public string? ConfirmNewPassword { get; set; }
    }
}
