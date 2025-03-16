using System;
using Microsoft.AspNetCore.Mvc;

namespace EShop.MVC.Areas.Admin.ViewComponents
{
    public class UserPanelViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
