using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductService productService, ICategoryService categoryService, IToastNotification toastNotification)
        {
            _productService = productService;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllAsync();
            return View(response.Data);//Bilerek hata kontrolü yapmadık, aslında doğru olan yapmak.
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _productService.UpdateIsActiveAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        [HttpDelete]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _productService.HardDeleteAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        [HttpDelete]
        public async Task<IActionResult> SoftDelete(int id)
        {
            Console.WriteLine("Silinecek Ürün Id: " + id);
            var response = await _productService.SoftDeleteAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }

        [NonAction]
        private async Task<List<SelectListItem>> GenerateCategoryList(List<int>? categoryIds = null)
        {
            var categories = (await _categoryService.GetAllActivesAsync()).Data;
            List<SelectListItem> categoryList = [];
            SelectListItem selectListItem;
            foreach (var category in categories!)
            {
                selectListItem = new SelectListItem();
                if (categoryIds == null)
                {
                    selectListItem.Selected = false;
                }
                else
                {
                    foreach (var categoryId in categoryIds)
                    {
                        if (categoryId == category.Id)
                        {
                            selectListItem.Selected = true;
                        }
                    }
                }
                selectListItem.Text = category.Name;
                selectListItem.Value = category.Id.ToString();
                categoryList.Add(selectListItem);
            }
            return categoryList;
        }
        public async Task<IActionResult> Create()
        {
            var categories = await GenerateCategoryList();
            ViewBag.Categories = categories;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel productCreateModel)
        {

            if (!ModelState.IsValid || productCreateModel.CategoryIds.Count == 0)
            {
                if (productCreateModel.CategoryIds.Count == 0)
                {
                    ModelState.AddModelError("CategoryIds", "En az bir kategori seçmelisiniz!");
                }
                var categories = await GenerateCategoryList((List<int>?)productCreateModel.CategoryIds);
                ViewBag.Categories = categories;
                return View(productCreateModel);
            }

            var response = await _productService.CreateAsync(productCreateModel);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Bir sorun oluştu!");
                var categories = await GenerateCategoryList((List<int>?)productCreateModel.CategoryIds);
                ViewBag.Categories = categories;
                return View(productCreateModel);
            }
            _toastNotification.AddSuccessToastMessage("Ürün başarıyla kaydedildi!");
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = (await _productService.GetByIdAsync(id)).Data;
            var categoryIds = response!.Categories.Select(x => x.Id).ToList();
            var categoryList = await GenerateCategoryList(categoryIds);
            ViewBag.Categories = categoryList;
            var productUpdateModel = new ProductUpdateModel
            {
                Id = response.Id,
                Name = response.Name,
                Properties = response.Properties,
                IsActive = response.IsActive,
                IsDeleted = response.IsDeleted,
                Price = response.Price
            };
            ViewBag.CurrentImageUrl = response.ImageUrl;
            return View(productUpdateModel);

        }
    
        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateModel productUpdateModel,  string currentImageUrl)
        {
            if (!ModelState.IsValid || productUpdateModel.CategoryIds.Count == 0)
            {
                if (productUpdateModel.CategoryIds.Count == 0)
                {
                    ModelState.AddModelError("CategoryIds", "En az bir kategori seçmelisiniz!");
                }
                var categories = await GenerateCategoryList((List<int>?)productUpdateModel.CategoryIds);
                ViewBag.Categories = categories;
                ViewBag.CurrentImageUrl =currentImageUrl;
                return View(productUpdateModel);
            }
            var response = await _productService.UpdateAsync(productUpdateModel);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Bir sorun oluştu!");
                var categories = await GenerateCategoryList((List<int>?)productUpdateModel.CategoryIds);
                ViewBag.Categories = categories;
                return View(productUpdateModel);
            }
            _toastNotification.AddSuccessToastMessage("Ürün başarıyla güncellendi!");
            return RedirectToAction("Index", "Product");
        }

    }
}
