using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index([FromQuery] int categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            if (!response.IsSuccessful)
            {
                return View(new ProductModel());
            }
            return View(response.Data);
        }
    }
}
