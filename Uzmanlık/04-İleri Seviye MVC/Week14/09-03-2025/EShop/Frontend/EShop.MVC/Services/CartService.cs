using System;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;

namespace EShop.MVC.Services;

public class CartService : ICartService
{
    private readonly IHttpClientService _httpClientService;

    public CartService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<ResponseModel<CartItemModel>> AddToCartAsync(int productId, int quantity = 1)
    {
        var response = await _httpClientService.PostAsync<object,ResponseModel<CartItemModel>>($"carts", new
        {
            ProductId = productId,
            Quantity = quantity
        });
        return response!;
    }

    public async Task<ResponseModel<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity)
    {
        var response = await _httpClientService.PutAsync<object,ResponseModel<NoContent>>($"carts/{cartItemId}/quantity?quantity={quantity}", null!);
        return response!;
    }

    public async Task<ResponseModel<NoContent>> ClearCartAsync()
    {
        var response = await _httpClientService.DeleteAsync<ResponseModel<NoContent>>($"carts/items");
        return response!;
    }

    public async Task<ResponseModel<CartModel>> GetCartAsync()
    {
        var response = await _httpClientService.GetAsync<ResponseModel<CartModel>>($"carts");
        return response!;
    }

    public async Task<ResponseModel<NoContent>> RemoveFromCartAsync(int cartItemId)
    {
        var response = await _httpClientService.DeleteAsync<ResponseModel<NoContent>>($"carts/cartItemId");
        return response!;
    }
}
