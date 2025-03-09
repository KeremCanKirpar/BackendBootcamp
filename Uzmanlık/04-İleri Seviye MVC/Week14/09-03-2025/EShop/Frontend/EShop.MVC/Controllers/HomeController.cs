using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;

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
        var response = await _productService.GetAllActivesAsync();
        
        return View(response.Data!.Take(8).ToList());
    }
}
