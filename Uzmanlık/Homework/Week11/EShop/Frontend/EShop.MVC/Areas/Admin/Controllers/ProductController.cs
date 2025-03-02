using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {   
        private readonly IProductService _productService;
        private readonly IToastNotification _toastr;

        public ProductController(IProductService productService, IToastNotification toastr)
        {
            _productService = productService;
            _toastr = toastr;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllActivesAsync();
            if(!response.IsSuccessful)
            {
                _toastr.AddErrorToastMessage(response.Error);
                return View(new List<ProductModel>());
            }
            return View(response.Data);
        }

    }
}
