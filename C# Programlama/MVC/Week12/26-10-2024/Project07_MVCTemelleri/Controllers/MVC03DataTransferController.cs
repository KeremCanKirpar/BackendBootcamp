using Microsoft.AspNetCore.Mvc;
using Project07_MVCTemelleri.Models;

namespace Project07_MVCTemelleri.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        List<Category> categoryList;
        List<Product> productList;
        public MVC03DataTransferController()
        {
            categoryList = [
                 new Category{Id=1,Name="Telefon",Description="Telefon Kategorisi"},
                new Category{Id=2,Name="Bilgisayar",Description="Bilgisayar Kategorisi"},
                new Category{Id=3,Name="Kitap",Description="Kitap Kategorisi"},
                new Category{Id=4,Name="Oyuncak",Description="Oyuncak Kategorisi"}
             ];
            productList = [
               new Product {Id=1, Name="Iphone 13", CategoryId = 1, Price=47000},
                new Product {Id=2, Name="Iphone 14", CategoryId = 1, Price=57000},
                new Product {Id=3, Name="Iphone 15", CategoryId = 1, Price=67000},
                new Product {Id=4, Name="Iphone 16", CategoryId = 1, Price=77000},
                new Product {Id=5, Name="Excalibur", CategoryId = 2, Price=27000},
                new Product {Id=6, Name="Macbook Air M3", CategoryId = 2, Price=37000},
                new Product {Id=7, Name="Kadınlar ülkesi", CategoryId = 3, Price=300},
                new Product {Id=8, Name="Cesur Yeni Dünya", CategoryId = 3, Price=200},
             ];
        }
        public ActionResult Index()
        {
            string name = "Kerem Can";
            ViewBag.WelcomeMessage = $"Hoşgeldin {name}";

            ViewBag.CategoryList = categoryList;
            ViewData["CategoryList"] = categoryList;
            return View();
        }

        public ActionResult ModelData()
        {

            //Model Bazlı Veri Yollama
            return View(categoryList);
        }

        public ActionResult HomePage()
        {
            string message = "Uygulamamıza Hoşgeldiniz!";
            Campaign campaign = new()
            {
                Id = 1,
                Title = "1000 TL Üzeri ücretsiz Kargo!",
                Description = "Sepet Toplamınız 1000 TL ve üzerindeyse kargo bizden",
                ImageUrl = "/image/kampanya.jpg"
            };

            HomePageModel model = new()
            {
                Categories = categoryList,
                Products = productList,
                Message = message,
                Campaign = campaign
            };
            return View(model);
        }
    }
}
