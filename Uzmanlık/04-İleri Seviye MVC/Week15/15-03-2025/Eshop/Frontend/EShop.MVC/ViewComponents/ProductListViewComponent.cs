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
        private readonly ILogger<ProductListViewComponent> _logger;

        public ProductListViewComponent(IProductService productService, ILogger<ProductListViewComponent> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("ProductListViewComponent.InvokeAsync başladı");
            try
            {
                var response = await _productService.GetAllAsync();
                if (!response.IsSuccessful)
                {
                    _logger.LogWarning("Ürünler getirilemedi: {Error}", response.Error);
                    return View(new List<ProductModel>());
                }
                _logger.LogInformation("Toplam {Count} ürün getirildi", response.Data?.Count ?? 0);
                return View(response.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürünler getirilirken hata oluştu");
                return View(new List<ProductModel>());
            }
        }
    }
}
