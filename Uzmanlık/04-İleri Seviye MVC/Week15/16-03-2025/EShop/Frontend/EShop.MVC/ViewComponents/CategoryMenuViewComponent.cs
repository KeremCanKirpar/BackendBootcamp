using System;
using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShop.MVC.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var response = await _categoryService.GetMenuItemsAsync();
                if (!response.IsSuccessful || response.Data == null)
                {
                    return View(new List<CategoryMenuItem>());
                }

                List<CategoryMenuItem> menuItems = [.. response.Data.Select(x => new CategoryMenuItem
                {
                    Id = x.Id,
                    Title = x.Name!
                })];
                return View(menuItems);
            }
            catch (Exception)
            {
                return View(new List<CategoryMenuItem>());
            }
        }
    }
}
