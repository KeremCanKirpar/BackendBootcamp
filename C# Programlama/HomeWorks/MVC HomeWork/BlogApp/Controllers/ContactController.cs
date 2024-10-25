using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class ContactController : Controller
    {
        List<ContactModel> contactModels;

        public ContactController()
        {
            contactModels = [
                new ContactModel {
                     AdSoyad="Kerem Can Kırpar" , Email="maverickbusiness@hotmail.com" 
                }
            ];

        }
        public ActionResult Index()
        {
            ViewBag.ContactList = contactModels;
            return View();
        }

        [HttpPost]
        public IActionResult Submit()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");

        }

    }
}
