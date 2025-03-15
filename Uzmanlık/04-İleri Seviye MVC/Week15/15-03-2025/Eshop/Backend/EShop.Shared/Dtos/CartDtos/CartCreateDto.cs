using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.CartDtos
{
    public class CartCreateDto
    {
        [Required(ErrorMessage = "Kullanıcı Id zorunludur.")]
        public string? ApplicationUserId { get; set; }
    }
}
