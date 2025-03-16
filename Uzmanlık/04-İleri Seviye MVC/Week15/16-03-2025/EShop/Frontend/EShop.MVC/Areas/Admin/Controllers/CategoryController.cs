using System;
using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public CategoryController(ICategoryService categoryService, IToastNotification toastNotification)
        {
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoryService.GetAllAdminAsync();
            return View(response.Data ?? []);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Lütfen tüm alanları doğru şekilde doldurunuz.");
                return View(model);
            }

            try
            {
                var response = await _categoryService.CreateAsync(model);
                if (!response.IsSuccessful)
                {
                    _toastNotification.AddErrorToastMessage(response.Error ?? "Kategori eklenirken bir hata oluştu.");
                    return View(model);
                }

                _toastNotification.AddSuccessToastMessage("Kategori başarıyla eklendi.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Kategori eklenirken beklenmeyen bir hata oluştu.");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Kategori bulunamadı.");
                return RedirectToAction(nameof(Index));
            }

            var updateModel = new CategoryUpdateModel
            {
                Id = response.Data!.Id,
                Name = response.Data.Name!,
                Description = response.Data.Description,
                IsActive = response.Data.IsActive,
                IsMenuItem = response.Data.IsMenuItem
            };

            ViewBag.CurrentImageUrl = response.Data.ImageUrl;
            return View(updateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Lütfen tüm alanları doğru şekilde doldurunuz.");
                var currentCategory = await _categoryService.GetByIdAsync(model.Id);
                if (currentCategory.IsSuccessful && currentCategory.Data != null)
                {
                    ViewBag.CurrentImageUrl = currentCategory.Data.ImageUrl;
                }
                return View(model);
            }

            try
            {
                var response = await _categoryService.UpdateAsync(model);
                if (!response.IsSuccessful)
                {
                    _toastNotification.AddErrorToastMessage(response.Error ?? "Kategori güncellenirken bir hata oluştu.");
                    var currentCategory = await _categoryService.GetByIdAsync(model.Id);
                    if (currentCategory.IsSuccessful && currentCategory.Data != null)
                    {
                        ViewBag.CurrentImage = currentCategory.Data.ImageUrl;
                    }
                    return View(model);
                }

                _toastNotification.AddSuccessToastMessage("Kategori başarıyla güncellendi.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Kategori güncellenirken beklenmeyen bir hata oluştu.");
                var currentCategory = await _categoryService.GetByIdAsync(model.Id);
                if (currentCategory.IsSuccessful && currentCategory.Data != null)
                {
                    ViewBag.CurrentImageUrl = currentCategory.Data.ImageUrl;
                }
                return View(model);
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(int id)
        {
            Console.WriteLine($"Id: {id}");
            var response = await _categoryService.SoftDeleteAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HardDelete(int id)
        {
            Console.WriteLine($"Id: {id}");
            var response = await _categoryService.HardDeleteAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateIsActive(int id)
        {

            var response = await _categoryService.UpdateIsActiveAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateIsMenuItem(int id)
        {
            var response = await _categoryService.UpdateIsMenuItemAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        public async Task<IActionResult> Trash()
        {
            var response = await _categoryService.GetAllAdminAsync(isDeleted: true);
            return View(response.Data ?? []);
        }
    }
}
