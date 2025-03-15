using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.CartDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/carts")]
    [ApiController]
    [Authorize]
    public class CartsController : CustomControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var response = await _cartService.GetCartAsync(GetUserId());
            return CreateResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            addToCartDto.ApplicationUserId = GetUserId();
            var response = await _cartService.AddToCartAsync(addToCartDto);
            return CreateResult(response);
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var response = await _cartService.RemoveFromCartAsync(cartItemId);
            return CreateResult(response);
        }

        [HttpPut("{cartItemId}/quantity")]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, [FromQuery] int quantity)
        {
            var changeQuantityDto = new ChangeQuantityDto(cartItemId, quantity);
            var response = await _cartService.ChangeQuantityAsync(changeQuantityDto);
            return CreateResult(response);
        }

        [HttpDelete("items")]
        public async Task<IActionResult> Clear()
        {
            var response = await _cartService.ClearCartAsync(GetUserId());
            return CreateResult(response);
        }
    }
}
