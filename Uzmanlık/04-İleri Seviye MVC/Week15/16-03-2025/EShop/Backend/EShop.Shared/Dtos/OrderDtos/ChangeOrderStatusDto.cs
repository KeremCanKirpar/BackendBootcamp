using EShop.Shared.ComplexTypes;

namespace EShop.Shared.Dtos.OrderDtos
{
    public class ChangeOrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}