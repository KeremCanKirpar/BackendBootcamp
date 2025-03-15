using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.AuthDtos
{
    public class ResetPasswordDto
    {
        public string? Token { get; set; }

        [Required(ErrorMessage = "Email alanı boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        public string? UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı alanı boş bırakılamaz")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string? ConfirmNewPassword { get; set; }
    }
}
