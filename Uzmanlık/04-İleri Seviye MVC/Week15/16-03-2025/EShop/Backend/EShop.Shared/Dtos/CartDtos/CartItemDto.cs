using EShop.Shared.Dtos.ProductDtos;

namespace EShop.Shared.Dtos.CartDtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = new ProductDto();
        public int Quantity { get; set; }
        public decimal ItemAmount => Product.Price * Quantity;
    }
}
