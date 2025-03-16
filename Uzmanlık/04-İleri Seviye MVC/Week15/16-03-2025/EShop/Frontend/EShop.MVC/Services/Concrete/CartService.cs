using System.Net.Http.Json;
using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;

namespace EShop.MVC.Services.Concrete;

public class CartService : ICartService
{
    private readonly IHttpClientService _httpClient;
    private const string BaseUrl = "carts";

    public CartService(IHttpClientService httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseModel<CartModel>> GetCartAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync<ResponseModel<CartModel>>($"{BaseUrl}");
            return response ?? new ResponseModel<CartModel> { IsSuccessful = false, Error = "Sepet bilgisi alınamadı." };
        }
        catch (Exception ex)
        {
            return new ResponseModel<CartModel> { IsSuccessful = false, Error = $"Sepet bilgisi alınırken bir hata oluştu: {ex.Message}" };
        }
    }

    public async Task<ResponseModel<CartItemModel>> AddToCartAsync(int productId, int quantity = 1)
    {
        try
        {
            var response = await _httpClient.PostAsync<object, ResponseModel<CartItemModel>>($"{BaseUrl}", new { productId, quantity });
            return response ?? new ResponseModel<CartItemModel> { IsSuccessful = false, Error = "Ürün sepete eklenemedi." };
        }
        catch (Exception ex)
        {
            return new ResponseModel<CartItemModel> { IsSuccessful = false, Error = $"Ürün sepete eklenirken bir hata oluştu: {ex.Message}" };
        }
    }

    public async Task<ResponseModel<NoContent>> UpdateCartItemAsync(int cartItemId, int quantity)
    {
        try
        {
            var response = await _httpClient.PutAsync<object, ResponseModel<NoContent>>($"{BaseUrl}/{cartItemId}/quantity/?quantity={quantity}", null!);
            return response ?? new ResponseModel<NoContent> { IsSuccessful = false, Error = "Sepet güncellenemedi." };
        }
        catch (Exception ex)
        {
            return new ResponseModel<NoContent> { IsSuccessful = false, Error = $"Sepet güncellenirken bir hata oluştu: {ex.Message}" };
        }
    }

    public async Task<ResponseModel<NoContent>> RemoveFromCartAsync(int cartItemId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync<ResponseModel<NoContent>>($"{BaseUrl}/{cartItemId}");
            return response ?? new ResponseModel<NoContent> { IsSuccessful = false, Error = "Ürün sepetten kaldırılamadı." };
        }
        catch (Exception ex)
        {
            return new ResponseModel<NoContent> { IsSuccessful = false, Error = $"Ürün sepetten kaldırılırken bir hata oluştu: {ex.Message}" };
        }
    }

    public async Task<ResponseModel<NoContent>> ClearCartAsync()
    {
        try
        {
            var response = await _httpClient.DeleteAsync<ResponseModel<NoContent>>($"{BaseUrl}/items");
            return response ?? new ResponseModel<NoContent> { IsSuccessful = false, Error = "Sepet temizlenemedi." };
        }
        catch (Exception ex)
        {
            return new ResponseModel<NoContent> { IsSuccessful = false, Error = $"Sepet temizlenirken bir hata oluştu: {ex.Message}" };
        }
    }
}