using System;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Abstract
{
    public interface IPaymentService
    {
        Task<ResponseModel<bool>> CheckoutAsync(OrderCreateModel orderCreateModel);
    }
}
