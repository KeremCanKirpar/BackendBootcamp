using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using EShop.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IToastNotification _toastNotification;

        public OrderController(IOrderService orderService, IToastNotification toastNotification)
        {
            _orderService = orderService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index([FromQuery] OrderStatus? status = null)
        {
            ViewBag.GetOrderStatusSelectList = new Func<OrderStatus, List<SelectListItem>>(GetOrderStatusSelectList);
            ViewBag.OrderStatus = status;
            var response = status == null
                ? await _orderService.GetAllAsync()
                : await _orderService.GetAllAsync((OrderStatus)status);
            return View(response.Data ?? []);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatus status)
        {
            var response = await _orderService.ChangeOrderStatusAsync(id, status);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        private List<SelectListItem> GetOrderStatusSelectList(OrderStatus selectedStatus)
        {
            return Enum.GetValues(typeof(OrderStatus))
                .Cast<OrderStatus>()
                .Select(x => new SelectListItem
                {
                    Text = x.GetType()
                        .GetField(x.ToString())
                        ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                        .Cast<DisplayAttribute>()
                        .FirstOrDefault()
                        ?.Name ?? x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = x == selectedStatus
                })
                .ToList();
        }
    }
}
