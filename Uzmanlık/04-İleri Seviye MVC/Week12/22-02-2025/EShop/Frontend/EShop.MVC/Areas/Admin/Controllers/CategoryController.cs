using System;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastr;

        public CategoryController(ICategoryService categoryService, IToastNotification toastr)
        {
            _categoryService = categoryService;
            _toastr = toastr;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoryService.GetAllActivesAsync();
            if (!response.IsSuccessful)
            {
                _toastr.AddErrorToastMessage(response.Error);
                return View(new List<CategoryModel>());
            }
            return View(response.Data);
        }

        public async Task<IActionResult> UpdateIsActive(int id)
        {
            return View();
        }
    }
}
