using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.MVC.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public ProfileController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _userService.GetMyProfileAsync();
        return View(response.Data);
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await _authService.ChangePasswordAsync(model);

        if (!response.IsSuccessful)
        {
            ModelState.AddModelError(string.Empty, response.Error!);
            return View(model);
        }

        TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirildi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UserUpdateModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        var response = await _userService.UpdateMyProfileAsync(model);

        if (!response.IsSuccessful)
            TempData["ErrorMessage"] = response.Error;
        else
            TempData["SuccessMessage"] = "Profiliniz başarıyla güncellendi.";

        return RedirectToAction(nameof(Index));
    }
}