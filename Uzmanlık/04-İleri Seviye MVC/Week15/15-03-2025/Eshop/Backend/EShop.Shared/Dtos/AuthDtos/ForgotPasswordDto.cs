using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.AuthDtos
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Kullanıcı adı ya da kayıt olurken girilen mail adresi bilgisi zorunludur!")]
        public string? UserNameOrEmail { get; set; }
    }
}
