using EShop.Shared.Dtos.AuthDtos;

namespace EShop.Shared.Dtos.CartDtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; } = new ApplicationUserDto();
        public ICollection<CartItemDto> CartItems { get; set; } = [];
        public decimal TotalAmount => CartItems.Sum(x => x.Product.Price * x.Quantity);
        public int ItemsCount => CartItems == null ? 0 : CartItems.Count;
    }
}
