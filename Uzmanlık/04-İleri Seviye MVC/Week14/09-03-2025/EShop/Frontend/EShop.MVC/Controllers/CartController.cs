using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IToastNotification _toastr;

        public CartController(ICartService cartService, IToastNotification toastr)
        {
            _cartService = cartService;
            _toastr = toastr;
        }
        
        public async Task<IActionResult> Index()
        {
           var response = await _cartService.GetCartAsync();
           if(!response.IsSuccessful)
           {
            _toastr.AddErrorToastMessage(response.Error ?? "Sepet Bilgisi Alınamadı");
            return RedirectToAction("Index", "Home");
           }
           return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            if(quantity<1)
            {
                _toastr.AddErrorToastMessage("Geçersiz Ürün Miktarı");
                return RedirectToAction("Index", "Home");
            }
            var response = await _cartService.AddToCartAsync(productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int cartItemId, int quantity)
        {
            if(quantity<1)
            {
                _toastr.AddErrorToastMessage("Geçersiz Ürün Miktarı");
                return RedirectToAction(nameof(Index));
            }
            var response = await _cartService.ChangeQuantityAsync(cartItemId, quantity);
            return RedirectToAction(nameof(Index));

        }

    }
}
