using System;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace EShop.MVC.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _client;

    public OrderService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("API");
    }

    public Task<ResponseModel<OrderModel>> CancelOrderStatus(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<List<OrderModel>>> GetAllAsync()
    {
        var httpResponseMessage = await _client.GetAsync("orders");
        var contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<ResponseModel<List<OrderModel>>>(contentResponse);
        return response;
    }

    public Task<ResponseModel<List<OrderModel>>> GetAllByDateStatus(DateTime starDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<OrderModel>>> GetAllMyOrderStatus()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<OrderModel>>> GetAllStatusAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<OrderModel>>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<OrderModel>>> GetByStatusAsync(OrderStatus status)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<OrderModel>> UpdateStatusAsync(int id)
    {
        throw new NotImplementedException();
    }
}
