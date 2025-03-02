using System;
using System.Xml.Linq;

namespace EShop.Shared.Dtos;

public class CartDto
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? ApplicationUserId { get; set; }
    public ApplicationUserDto ApplicationUser { get; set; } = new ApplicationUserDto();
    public ICollection<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();

    public decimal TotalAmount => CartItems.Sum(x => x.Product.Price * x.Quantity);

    public int TotalItems => CartItems == null ? 0 : CartItems.Count();
}







// public decimal TotalPrice
// {
//     get
//     {
//         return CartItems.Sum(x => x.Product.Price * x.Quantity);
//     }
// }



// public decimal TotalPrice() => CartItems.Sum(x => x.Product.Price * x.Quantity);

// public decimal TotalPrice()
// {
//     decimal totalPrice = 0;
//     foreach (var item in CartItems)
//     {
//         totalPrice += item.Product.Price * item.Quantity;
//     }

//     return totalPrice;
// }
