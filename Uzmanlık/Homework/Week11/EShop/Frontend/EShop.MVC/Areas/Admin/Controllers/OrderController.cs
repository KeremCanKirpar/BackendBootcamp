using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IToastNotification _toastr;

        public OrderController(IOrderService orderService, IToastNotification toastr)
        {
            _orderService = orderService;
            _toastr = toastr;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _orderService.GetAllAsync();
            if (!response.IsSuccessful)
            {
                _toastr.AddErrorToastMessage(response.Error ?? "Sipariş verileri alınamadı.");
                return View(new List<OrderModel>());
            }
            return View(response.Data);
        }
    }
}
