using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrdersController : CustomControllerBase
    {
        private readonly IOrderService _orderManager;

        public OrdersController(IOrderService orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            orderCreateDto.ApplicationUserId = GetUserId();
            var response = await _orderManager.AddAsync(orderCreateDto);
            return CreateResult(response);
        }
    }
}
