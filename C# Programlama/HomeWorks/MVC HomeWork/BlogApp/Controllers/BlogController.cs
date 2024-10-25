using System.Reflection.Metadata;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        List<BlogModel> blogModeList;

        public BlogController()
        {
            blogModeList = [

                new BlogModel
                {
                    Id=1, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="123", Resim="https://picsum.photos/id/213/200/300"
                },
                new BlogModel
                {
                    Id=2, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="03", Resim="https://picsum.photos/id/343/200/300"
                },
                new BlogModel
                {
                    Id=3, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="12", Resim="https://picsum.photos/id/653/200/300"
                },
                new BlogModel
                {
                    Id=4, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik=" 67 ", Resim="https://picsum.photos/id/324/200/300"
                },
                new BlogModel
                {
                    Id=5, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="31", Resim="https://picsum.photos/id/123/200/300"
                },
                new BlogModel
                {
                    Id=6, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="22", Resim="https://picsum.photos/id/12/200/300"
                },
                new BlogModel
                {
                    Id=7, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="2İ", Resim="https://picsum.photos/id/345/200/300"
                },
                new BlogModel
                {
                    Id=8, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="4", Resim="https://picsum.photos/id/234/200/300"
                },
                new BlogModel
                {
                    Id=9, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="3", Resim="https://picsum.photos/id/297/200/300"
                },
                new BlogModel
                {
                    Id=10, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="V4", Resim="https://picsum.photos/id/337/200/300"
                },
                new BlogModel
                {
                    Id=11, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="5", Resim="https://picsum.photos/id/200/200/300"
                },
                new BlogModel
                {
                    Id=12, Aciklama="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.", Baslik="7", Resim="https://picsum.photos/id/12/200/300"
                },


            ];

        }
        public ActionResult Index()
        {

            ViewData["BlogModelList"] = blogModeList;
            return View();
        }

    }
}
