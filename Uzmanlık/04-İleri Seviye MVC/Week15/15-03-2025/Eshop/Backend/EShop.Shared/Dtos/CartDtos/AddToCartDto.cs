using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.Shared.Dtos.CartDtos
{
    public class AddToCartDto
    {
        [JsonIgnore]
        public string ApplicationUserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ürün Id zorunludur.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ürün miktarı zorunludur.")]
        public int Quantity { get; set; }
    }
}
