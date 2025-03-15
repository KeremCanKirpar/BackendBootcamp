using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.AuthDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı adı ya da kayıt olurken girilen mail adresi bilgisi zorunludur!")]
        public string? UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Parola zorunludur!")]
        public string? Password { get; set; }
    }
}
