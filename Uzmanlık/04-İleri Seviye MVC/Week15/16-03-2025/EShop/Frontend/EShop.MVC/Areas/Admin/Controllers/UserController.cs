using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IToastNotification _toastNotification;

        public UserController(IUserService userService, IToastNotification toastNotification)
        {
            _userService = userService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _userService.GetAllAsync();

            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Üyeler getirilirken bir hata oluştu.");
                return View(new List<UserModel>());
            }

            return View(response.Data);
        }

        public async Task<IActionResult> Details(string id)
        {
            var response = await _userService.GetByIdAsync(id);

            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Üye bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoles(string userId, List<string> roles)
        {
            try
            {
                var response = await _userService.UpdateRolesAsync(userId, roles);

                if (!response.IsSuccessful)
                {
                    return Json(new { isSuccessful = false, error = response.Error });
                }

                return Json(new { isSuccessful = true });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccessful = false, error = ex.Message });
            }
        }
    }
}