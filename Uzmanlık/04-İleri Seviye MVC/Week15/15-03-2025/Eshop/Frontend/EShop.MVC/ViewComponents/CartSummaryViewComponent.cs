using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EShop.MVC.ViewComponents;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly ICartService _cartService;

    public CartSummaryViewComponent(ICartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
            return View(0);

        var response = await _cartService.GetCartAsync();
        return View(response.IsSuccessful ? response.Data?.TotalItems ?? 0 : 0);
    }
}