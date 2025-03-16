using EShop.Services.Abstract;
using EShop.Shared.ComplexTypes;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.OrderDtos;
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
        public async Task<IActionResult> AddOrder([FromBody] OrderNowDto orderNowDto)
        {
            orderNowDto.ApplicationUserId = GetUserId();
            var response = await _orderManager.OrderNowAsync(orderNowDto);
            return CreateResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _orderManager.GetAsync(id);
            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OrderStatus? status = null)
        {
            var response = await _orderManager.GetAllAsync(status);
            return CreateResult(response);
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetMyOrders([FromQuery] OrderStatus? status = null)
        {
            var userId = GetUserId();
            var response = await _orderManager.GetAllAsync(status, userId);
            return CreateResult(response);
        }

        [HttpGet("bydate")]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var response = await _orderManager.GetAllAsync(startDate, endDate);
            return CreateResult(response);
        }

        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> ChangeStatus(int orderId, [FromQuery] OrderStatus orderStatus)
        {
            var response = await _orderManager.ChangeOrderStatusAsync(orderId, orderStatus);
            Console.WriteLine("Durum: " + response.IsSuccessful);
            return CreateResult(response);
        }

        [HttpPut("{orderId}/cancel")]
        public async Task<IActionResult> Cancel(int orderId)
        {
            var response = await _orderManager.CancelOrderAsync(orderId);
            return CreateResult(response);
        }
    }
}
