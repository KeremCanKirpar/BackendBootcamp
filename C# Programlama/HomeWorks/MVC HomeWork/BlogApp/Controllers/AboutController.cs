using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class AboutController : Controller
    {

        public ActionResult Index()
        {
            AboutModel about = new AboutModel { AdSoyad = "Kerem Can Kırpar", Aciklama = " Merhaba ben Kerem Can Kırpar 7 yıldır yazılım alanında kendimi geliştirmeye çalışıyorum ", StajYer = "Mondelez Türkiye", Resim = "https://picsum.photos/id/1/200/200", };

            List<LinkModel> links = new List<LinkModel>();
            links.Add(new LinkModel
            {
                LinkName = "Github",
                LinkUrl = "https://github.com/KeremCanKirpar"
            });

            links.Add(new LinkModel
            {
                LinkName = "Linkedin",
                LinkUrl = "https://www.linkedin.com/in/kerem-can-kırpar-4477b0276/"
            });
            about.Links = links;

            List<Staj> stajyer = new List<Staj>();

            stajyer.Add(new Staj
            {
                StajName = "Mondalez Türkiye",

            });
            stajyer.Add(new Staj
            {
                StajName = "Riot games Türkiye",

            });
            about.Staj = stajyer;

            // ViewBag.AboutList = aboutModels;
            return View(about);
        }

    }
}
