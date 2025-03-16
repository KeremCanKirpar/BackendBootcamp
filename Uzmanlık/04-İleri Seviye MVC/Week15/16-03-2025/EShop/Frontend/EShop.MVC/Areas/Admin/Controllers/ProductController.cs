using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers;

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
        var response = await _productService.GetAllAdminAsync(includeCategories: true);
        if (!response.IsSuccessful)
        {
            _toastNotification.AddErrorToastMessage(response.Error ?? "Ürünler getirilirken bir hata oluştu.");
            return View(new List<ProductModel>());
        }
        return View(response.Data);
    }

    public async Task<IActionResult> Create()
    {
        var categoryList = await GenerateCategoryList();
        ViewBag.Categories = categoryList;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCreateModel model)
    {
        // Fiyat değerini kültür ayarlarına göre düzenleme
        if (model.Price.HasValue)
        {
            var priceString = model.Price.Value.ToString().Replace(',', '.');
            if (decimal.TryParse(priceString, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal parsedPrice))
            {
                model.Price = parsedPrice;
            }
        }

        if (!ModelState.IsValid)
        {
            _toastNotification.AddErrorToastMessage("Lütfen tüm alanları doğru şekilde doldurunuz.");
            var categoryList = await GenerateCategoryList();
            ViewBag.Categories = categoryList;
            return View(model);
        }

        try
        {
            var response = await _productService.CreateAsync(model);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Ürün eklenirken bir hata oluştu.");
                var categoryList = await GenerateCategoryList();
                ViewBag.Categories = categoryList;
                return View(model);
            }

            _toastNotification.AddSuccessToastMessage("Ürün başarıyla eklendi.");
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            _toastNotification.AddErrorToastMessage("Ürün eklenirken beklenmeyen bir hata oluştu.");
            var categoryList = await GenerateCategoryList();
            ViewBag.Categories = categoryList;
            return View(model);
        }
    }


    [NonAction]
    private async Task<List<SelectListItem>> GenerateCategoryList(List<int>? categoryIds = null)
    {
        var categories = (await _categoryService.GetAllAdminAsync(isActive: true, isDeleted: false)).Data;
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


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var response = (await _productService.GetByIdAsync(id)).Data;
        var categoryIds = response!.Categories.Select(x => x.Id).ToList();
        var categoryList = await GenerateCategoryList(categoryIds);
        ViewBag.Categories = categoryList;

        var updateModel = new ProductUpdateModel
        {
            Id = response.Id,
            Name = response.Name,
            Properties = response.Properties,
            Price = response.Price,
            CategoryIds = response.Categories.Select(c => c.Id).ToList(),
            IsHome = response.IsHome
        };

        ViewBag.CurrentImageUrl = response.ImageUrl;
        return View(updateModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductUpdateModel model, string currentImageUrl)
    {
        // Fiyat değerini kültür ayarlarına göre düzenleme
        if (model.Price.HasValue)
        {
            var priceString = model.Price.Value.ToString().Replace(',', '.');
            if (decimal.TryParse(priceString, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal parsedPrice))
            {
                model.Price = parsedPrice;
            }
        }

        if (!ModelState.IsValid)
        {
            _toastNotification.AddErrorToastMessage("Lütfen tüm alanları doğru şekilde doldurunuz.");
            var categoryList = await GenerateCategoryList([.. model.CategoryIds]);
            ViewBag.Categories = categoryList;
            ViewBag.CurrentImageUrl = currentImageUrl;
            return View(model);
        }

        try
        {
            var response = await _productService.UpdateAsync(model);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Ürün güncellenirken bir hata oluştu.");
                var categoryList = await GenerateCategoryList([.. model.CategoryIds]);
                ViewBag.Categories = categoryList;
                ViewBag.CurrentImageUrl = currentImageUrl;
                return View(model);
            }

            _toastNotification.AddSuccessToastMessage("Ürün başarıyla güncellendi.");
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            _toastNotification.AddErrorToastMessage("Ürün güncellenirken beklenmeyen bir hata oluştu.");
            var categoryList = await GenerateCategoryList([.. model.CategoryIds]);
            ViewBag.Categories = categoryList;
            ViewBag.CurrentImageUrl = currentImageUrl;
            return View(model);
        }
    }

    [HttpPut]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var response = await _productService.SoftDeleteAsync(id);
        return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
    }

    [HttpDelete]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> HardDelete(int id)
    {
        var response = await _productService.HardDeleteAsync(id);
        return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
    }

    [HttpPut]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateIsActive(int id)
    {
        try
        {
            var response = await _productService.UpdateIsActiveAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }
        catch (Exception)
        {
            return Json(new { isSuccessful = false, error = "Ürün durumu güncellenirken bir hata oluştu." });
        }
    }

    [HttpPut]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateIsHome(int id)
    {
        try
        {
            var response = await _productService.UpdateIsHomeAsync(id);
            return Json(new { isSuccessful = response.IsSuccessful, error = response.Error });
        }
        catch (Exception)
        {
            return Json(new { isSuccessful = false, error = "Ürün durumu güncellenirken bir hata oluştu." });
        }
    }

    public async Task<IActionResult> Trash()
    {
        var response = await _productService.GetAllAdminAsync(isDeleted: true);
        return View(response.Data ?? []);
    }

}