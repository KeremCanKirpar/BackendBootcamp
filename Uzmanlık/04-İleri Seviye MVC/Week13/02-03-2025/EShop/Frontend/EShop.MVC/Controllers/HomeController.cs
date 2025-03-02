using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShop.MVC.Models;

namespace EShop.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
