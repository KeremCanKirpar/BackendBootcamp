using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IToastNotification _toastNotification;

        public RoleController(IRoleService roleService, IToastNotification toastNotification)
        {
            _roleService = roleService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _roleService.GetAllAsync();

            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Roller getirilirken bir hata oluştu.");
                return View(new List<RoleModel>());
            }

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string roleName)
        {
            try
            {
                var response = await _roleService.CreateAsync(roleName);

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

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var response = await _roleService.DeleteAsync(id);

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