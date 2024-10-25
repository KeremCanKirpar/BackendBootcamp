using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class AboutController : Controller
    {
        List<AboutModel> aboutModels;
        public AboutController()
        {
            aboutModels = [
                new AboutModel { AdSoyad="Kerem Can Kırpar", Aciklama="Merhaba ben Kerem Can Kırpar  7 yıldır yazılım alanında kendimi geliştirmek için çeşitli projeler geliştiriyorum." , Link="https://github.com/KeremCanKirpar", Resim="https://picsum.photos/id/1/120/120"},
            ];

        }
        public ActionResult Index()
        {
            ViewBag.AboutList = aboutModels;
            return View();
        }

    }
}
