using System;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Interfaces;

public interface ICartService
{
    Task<ResponseModel<CartModel>> GetCartAsync();
    Task<ResponseModel<CartItemModel>> AddToCartAsync(int productId, int quantity=1);
    Task<ResponseModel<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity);
    Task<ResponseModel<NoContent>> RemoveFromCartAsync(int cartItemId);
    Task<ResponseModel<NoContent>> ClearCartAsync();
}
