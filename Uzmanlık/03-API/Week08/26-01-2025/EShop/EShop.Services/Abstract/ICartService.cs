using System;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface ICartService
{
    Task<ResponseDto<CartDto>> CreateCartAsync(string applicationUserId);
    Task<ResponseDto<CartDto>> GetCartAsync(string applicationUserId);
    Task<ResponseDto<CartItemDto>> AddToCartAsync(CartItemCreateDto cartItemCreateDto);
    Task<ResponseDto<NoContent>> RemoveFromCartAsync(int cartItemId);
    Task<ResponseDto<NoContent>> ClearCartAsync(string applicationUserId);
    Task<ResponseDto<CartItemDto>> ChangeQuantityAsync(CartItemUpdateDto cartItemUpdateDto);
}
