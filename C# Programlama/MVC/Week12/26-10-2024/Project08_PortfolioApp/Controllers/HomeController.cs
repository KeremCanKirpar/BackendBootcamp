using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Project08_PortfolioApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}
