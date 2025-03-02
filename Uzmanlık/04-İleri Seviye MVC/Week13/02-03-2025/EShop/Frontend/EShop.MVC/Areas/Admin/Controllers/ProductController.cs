using System.Threading.Tasks;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastr;

        public ProductController(IProductService productService, IToastNotification toastr, ICategoryService categoryService)
        {
            _productService = productService;
            _toastr = toastr;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllAsync();
            return View(response.Data); // bilerek Hata Kontrolü yapmadık
        }
        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _productService.UpdateIsActiveAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }
        [HttpDelete]
        public async Task<IActionResult>HardDelete(int id)
        {
            var response = await _productService.HardDeleteAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }
        [HttpDelete]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _productService.SoftDeleteAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }
    }
}
