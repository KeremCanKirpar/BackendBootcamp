using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using System.Threading.Tasks;

namespace EShop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _productService.GetAllAsync();
        Random rnd = new Random();
        if (!response.IsSuccessful)
        {
            return View(new ProductModel());
        }
        return View(response.Data![rnd.Next(response.Data.Count())]);
    }
}
