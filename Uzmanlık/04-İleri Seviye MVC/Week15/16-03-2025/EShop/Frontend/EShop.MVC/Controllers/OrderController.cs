using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IToastNotification _toastNotification;

        public OrderController(IPaymentService paymentService, IOrderService orderService, IToastNotification toastNotification, ICartService cartService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
            _toastNotification = toastNotification;
            _cartService = cartService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Checkout()
        {
            var cart = (await _cartService.GetCartAsync()).Data;
            OrderCreateModel orderCreateModel = new()
            {
                OrderItems = cart!.CartItems.Select(x => new OrderItemCreateModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    UnitPrice = x.Product.Price
                }).ToList()
            };
            return View(orderCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderCreateModel model)
        {
            var cart = (await _cartService.GetCartAsync()).Data;
            model.OrderItems = cart!.CartItems.Select(x => new OrderItemCreateModel
            {
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                Quantity = x.Quantity,
                UnitPrice = x.Product.Price
            }).ToList();

            var response = await _paymentService.CheckoutAsync(model);
            if (!response!.Data)
            {
                _toastNotification.AddErrorToastMessage(response.Error);
                return View(model);
            }
            var responseModel = await _orderService.AddAsync(model);
            _toastNotification.AddSuccessToastMessage("Ödeme ve Sipariş İşlemleri Başarıyla Tamamlanmıştır!");
            return RedirectToAction("Index", "Home");
        }
    }
}
