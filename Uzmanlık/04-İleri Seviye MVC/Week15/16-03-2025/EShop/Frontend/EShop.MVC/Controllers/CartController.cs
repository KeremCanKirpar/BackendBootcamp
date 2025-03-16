using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IToastNotification _toastNotification;

    public CartController(ICartService cartService, IToastNotification toastNotification)
    {
        _cartService = cartService;
        _toastNotification = toastNotification;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var response = await _cartService.GetCartAsync();
        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Sepet bilgisi alınamadı.");
            return RedirectToAction("Index", "Home");
        }

        return View(response.Data);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
        if (quantity < 1)
        {
            _toastNotification.AddErrorToastMessage("Geçersiz miktar.");
            return RedirectToAction("Index", "Home");
        }

        var response = await _cartService.AddToCartAsync(productId, quantity);
        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Ürün sepete eklenemedi.");
            return RedirectToAction("Index", "Home");
        }

        _toastNotification.AddSuccessToastMessage("Ürün sepete eklendi.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
    {
        if (quantity < 1)
        {
            _toastNotification.AddErrorToastMessage("Geçersiz miktar.");
            return RedirectToAction(nameof(Index));
        }

        var response = await _cartService.UpdateCartItemAsync(cartItemId, quantity);
        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Ürün miktarı güncellenemedi.");
            return RedirectToAction(nameof(Index));
        }

        _toastNotification.AddSuccessToastMessage("Ürün miktarı güncellendi.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int cartItemId)
    {
        var response = await _cartService.RemoveFromCartAsync(cartItemId);
        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Ürün sepetten kaldırılamadı.");
            return RedirectToAction(nameof(Index));
        }

        _toastNotification.AddSuccessToastMessage("Ürün sepetten kaldırıldı.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ClearCart()
    {
        var response = await _cartService.ClearCartAsync();
        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Sepet temizlenemedi.");
            return RedirectToAction(nameof(Index));
        }

        _toastNotification.AddSuccessToastMessage("Sepet temizlendi.");
        return RedirectToAction(nameof(Index));
    }
}