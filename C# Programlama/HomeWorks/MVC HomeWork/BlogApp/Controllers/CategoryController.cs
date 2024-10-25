using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class CategoryController : Controller
    {
        List<CategoryModel> categoryModels;
        public CategoryController()
        {
            categoryModels = [
                new CategoryModel {
                    Kategory="Bilgisayar"
                },
                new CategoryModel {
                    Kategory="Tablet"
                },
                new CategoryModel {
                    Kategory="Telefon"
                },
            ];

        }

        public ActionResult Index()
        {

            ViewBag.CategoryList=categoryModels;
            return View();
        }

    }
}
