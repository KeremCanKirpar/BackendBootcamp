using System;
using EShop.Entity.Abstract;

namespace EShop.Entity.Concrete;

public class Cart : BaseEntity
{
    private Cart()
    {
    }
    public Cart(string? applicationUserId)
    {
        ApplicationUserId = applicationUserId;
    }
    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    public ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();
}
