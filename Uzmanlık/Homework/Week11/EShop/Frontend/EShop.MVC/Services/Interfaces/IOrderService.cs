using System;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseModel<List<OrderModel>>> GetAllAsync();
        Task<ResponseModel<List<OrderModel>>> GetByIdAsync(int id);
        Task<ResponseModel<List<OrderModel>>> GetByStatusAsync(OrderStatus status);
        Task<ResponseModel<List<OrderModel>>> GetAllStatusAsync();
        Task<ResponseModel<List<OrderModel>>> GetAllByDateStatus(DateTime starDate, DateTime endDate);
        Task<ResponseModel<List<OrderModel>>> GetAllMyOrderStatus();
        Task<ResponseModel<OrderModel>> UpdateStatusAsync(int id);
        Task<ResponseModel<OrderModel>> CancelOrderStatus(int id);
    }
}
