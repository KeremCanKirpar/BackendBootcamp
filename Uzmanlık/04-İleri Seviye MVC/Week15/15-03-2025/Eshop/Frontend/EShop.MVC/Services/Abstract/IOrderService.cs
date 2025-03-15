using System;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Abstract
{
    public interface IOrderService
    {
        Task<ResponseModel<OrderModel>> AddAsync(OrderCreateModel orderCreateModel);
        Task<ResponseModel<NoContent>> ChangeOrderStatusAsync(int id, OrderStatus orderStatus);
        Task<ResponseModel<OrderModel>> GetAsync(int id);
        Task<ResponseModel<List<OrderModel>>> GetAllAsync();
        Task<ResponseModel<List<OrderModel>>> GetAllAsync(OrderStatus orderStatus);
        Task<ResponseModel<List<OrderModel>>> GetAllByDateAsync();
        Task<ResponseModel<List<OrderModel>>> GetAllMyAsync();
        Task<ResponseModel<List<OrderModel>>> GetAllMyAsync(OrderStatus orderStatus);


    }
}
