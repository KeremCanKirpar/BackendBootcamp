using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EfCore.UI.Models;

namespace EfCore.UI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
