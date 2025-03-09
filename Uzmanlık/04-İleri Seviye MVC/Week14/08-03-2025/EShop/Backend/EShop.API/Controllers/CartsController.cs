using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : CustomControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var response = await _cartService.GetCartAsync(GetUserId());
            return CreateResult(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartItemCreateDto cartItemCreateDto)
        {
            var response = await _cartService.AddToCartAsync(cartItemCreateDto);
            return CreateResult(response);
        }

        [Authorize]
        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var response = await _cartService.RemoveFromCartAsync(cartItemId);
            return CreateResult(response);
        }

        [Authorize]
        [HttpPut("quantity")]
        public async Task<IActionResult> ChangeQuantity([FromBody] CartItemUpdateDto cartItemUpdateDto)
        {
            var response = await _cartService.ChangeQuantityAsync(cartItemUpdateDto);
            return CreateResult(response);
        }

        [Authorize]
        [HttpDelete("clear")]
        public async Task<IActionResult> Clear()
        {
            var response = await _cartService.ClearCartAsync(GetUserId());
            return CreateResult(response);
        }
    }
}
