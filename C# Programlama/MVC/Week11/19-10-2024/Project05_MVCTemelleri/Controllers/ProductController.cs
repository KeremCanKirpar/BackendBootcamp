using System;
using Microsoft.AspNetCore.Mvc;

namespace Project05_MVCTemelleri.Controllers;


public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}