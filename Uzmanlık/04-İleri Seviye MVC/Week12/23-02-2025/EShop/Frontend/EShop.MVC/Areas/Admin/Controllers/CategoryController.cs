using System;
using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
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
            var response = await _categoryService.GetAllAsync();
            if (!response.IsSuccessful && response.Data == null)
            {
                return View(new List<CategoryModel>());
            }
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateModel categoryCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryCreateModel);
            }
            var response = await _categoryService.CreateAsync(categoryCreateModel);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddWarningToastMessage(response.Error ?? "Server'dan kaynaklı bir sorun oluştu!");
                return View(categoryCreateModel);
            }
            _toastNotification.AddSuccessToastMessage("Kategori başarıyla kaydedildi!");
            // return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _categoryService.GetAsync(id);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Kategori bulunamadı!");
                return RedirectToAction(nameof(Index));
            }
            var categoryUpdateModel = new CategoryUpdateModel
            {
                Id = response.Data!.Id,
                Name = response.Data.Name,
                Description = response.Data.Description,
                IsActive = response.Data.IsActive,
                IsDeleted = response.Data.IsDeleted
            };
            ViewBag.CurrentImageUrl = response.Data.ImageUrl;
            return View(categoryUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateModel categoryUpdateModel, string currentImageUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CurrentImageUrl = currentImageUrl;
                return View(categoryUpdateModel);
            }
            var response = await _categoryService.UpdateAsync(categoryUpdateModel);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddWarningToastMessage(response.Error ?? "Server'dan kaynaklı bir sorun oluştu!");
                ViewBag.CurrentImageUrl = currentImageUrl;
                return View(categoryUpdateModel);
            }
            _toastNotification.AddSuccessToastMessage("Kategori bilgileri başarıyla güncellenmiştir!");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _categoryService.UpdateIsActive(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }
    }
}
