using EShop.Shared.ComplexTypes;
using EShop.Shared.Dtos.AuthDtos;

namespace EShop.Shared.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; } = new ApplicationUserDto();
        public string? Address { get; set; }
        public string? City { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = [];
        public decimal TotalAmount => OrderItems.Sum(x => x.ItemAmount);
    }
}
