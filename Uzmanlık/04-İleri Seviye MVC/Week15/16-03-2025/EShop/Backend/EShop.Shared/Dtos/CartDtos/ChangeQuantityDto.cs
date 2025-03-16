using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.CartDtos
{
    public class ChangeQuantityDto
    {
        public ChangeQuantityDto(int cartItemId, int quantity)
        {
            CartItemId = cartItemId;
            Quantity = quantity;
        }
        [Required(ErrorMessage = "Sepet item id'si zorunludur.")]
        public int CartItemId { get; set; }

        [Required(ErrorMessage = "Ürün miktarı zorunludur.")]
        public int Quantity { get; set; }
    }
}
