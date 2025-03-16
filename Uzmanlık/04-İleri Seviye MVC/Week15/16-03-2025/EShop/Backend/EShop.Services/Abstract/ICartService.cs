using EShop.Shared.Dtos.CartDtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract
{
    public interface ICartService
    {
        Task<ResponseDto<CartDto>> CreateCartAsync(string applicationUserId);
        Task<ResponseDto<CartDto>> GetCartAsync(string applicationUserId);
        Task<ResponseDto<CartItemDto>> AddToCartAsync(AddToCartDto addToCartDto);
        Task<ResponseDto<NoContent>> RemoveFromCartAsync(int cartItemId);
        Task<ResponseDto<NoContent>> ClearCartAsync(string applicationUserId);
        Task<ResponseDto<CartItemDto>> ChangeQuantityAsync(ChangeQuantityDto changeQuantityDto);
    }
}
