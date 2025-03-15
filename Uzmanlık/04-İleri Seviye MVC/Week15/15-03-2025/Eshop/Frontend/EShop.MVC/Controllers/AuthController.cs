using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly IToastNotification _toastNotification;

    public AuthController(IAuthService authService, IToastNotification toastNotification)
    {
        _authService = authService;
        _toastNotification = toastNotification;
    }

    public IActionResult Login(string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model, string? returnUrl)
    {
        if (!ModelState.IsValid)
        {
            _toastNotification.AddErrorToastMessage("Lütfen tüm alanları doğru şekilde doldurunuz.");
            return View(model);
        }

        var response = await _authService.LoginAsync(model);
        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Giriş yapılırken bir hata oluştu.");
            return View(model);
        }

        _toastNotification.AddSuccessToastMessage("Giriş başarılı!");
        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        _toastNotification.AddSuccessToastMessage("Çıkış başarılı!");
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}