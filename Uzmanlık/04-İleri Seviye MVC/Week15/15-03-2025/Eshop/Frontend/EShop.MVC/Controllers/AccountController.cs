using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IToastNotification _toastNotification;
    private readonly IAuthService _authService;
    private readonly IOrderService _orderService;

    public AccountController(IUserService userService, IToastNotification toastNotification, IAuthService authService, IOrderService orderService)
    {
        _userService = userService;
        _toastNotification = toastNotification;
        _authService = authService;
        _orderService = orderService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _userService.GetMyProfileAsync();

        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Profil bilgileri getirilirken bir hata oluştu.");
            return RedirectToAction("Index", "Home");
        }

        var userUpdateModel = new UserUpdateModel
        {
            Id = response.Data!.Id,
            FirstName = response.Data.FirstName!,
            LastName = response.Data.LastName!,
            Email = response.Data.Email!,
            PhoneNumber = response.Data.PhoneNumber
        };

        return View(userUpdateModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UserUpdateModel model)
    {
        if (!ModelState.IsValid)
        {
            _toastNotification.AddErrorToastMessage("Lütfen tüm alanları doğru şekilde doldurunuz.");
            return RedirectToAction(nameof(Index));
        }

        var response = await _userService.UpdateMyProfileAsync(model);

        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Profil güncellenirken bir hata oluştu.");
            return RedirectToAction(nameof(Index));
        }

        _toastNotification.AddSuccessToastMessage("Profiliniz başarıyla güncellendi.");
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _authService.LoginAsync(model);

        if (!response.IsSuccessful)
        {
            ModelState.AddModelError(string.Empty, response.Error!);
            return View(model);
        }

        return Redirect(returnUrl ?? "/");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _authService.RegisterAsync(model);

        if (!response.IsSuccessful)
        {
            ModelState.AddModelError(string.Empty, response.Error!);
            return View(model);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı. Lütfen giriş yapın.";
        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _authService.ForgotPasswordAsync(model);

        if (!response.IsSuccessful)
        {
            ModelState.AddModelError(string.Empty, response.Error!);
            return View(model);
        }

        TempData["SuccessMessage"] = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.";
        return RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public IActionResult ResetPassword([FromQuery] string email, [FromQuery] string token)
    {
        var model = new ResetPasswordModel
        {
            Email = email,
            Token = token
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _authService.ResetPasswordAsync(model);

        if (!response.IsSuccessful)
        {
            ModelState.AddModelError(string.Empty, response.Error!);
            return View(model);
        }

        TempData["SuccessMessage"] = "Şifreniz başarıyla sıfırlandı. Lütfen yeni şifrenizle giriş yapın.";
        return RedirectToAction(nameof(Login));
    }

    [Authorize]
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _authService.ChangePasswordAsync(model);

        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error!);
            return View(model);
        }

        _toastNotification.AddSuccessToastMessage("Şifreniz başarıyla değiştirildi.");
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        var response = await _orderService.GetAllMyAsync();
        return View();
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> OrderByStatus(OrderStatus orderStatus)
    {
        var response = await _orderService.GetAllMyAsync(orderStatus);
        return View();
    }
}