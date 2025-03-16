using System;
using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Logging;

namespace EShop.MVC.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductListViewComponent(IProductService productService, ILogger<ProductListViewComponent> logger)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? categoryId = null)
        {
            try
            {
                var response = categoryId == null || categoryId == 0
                    ? await _productService.GetAllAsync()
                    : await _productService.GetAllAdminAsync(isActive: true, categoryId: categoryId);
                if (!response.IsSuccessful)
                {
                    return View(new List<ProductModel>());
                }
                return View(response.Data);
            }
            catch (Exception ex)
            {
                return View(new List<ProductModel>());
            }
        }
    }
}
