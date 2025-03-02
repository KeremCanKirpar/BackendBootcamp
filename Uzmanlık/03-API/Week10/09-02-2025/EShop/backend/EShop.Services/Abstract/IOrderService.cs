using System;
using EShop.Shared.ComplexTypes;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface IOrderService
{
    Task<ResponseDto<OrderDto>> GetAsync(int id);
    Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync();
    Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync(OrderStatus orderStatus, string? applicationUserId = null);
    Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync(string applicationUserId);
    Task<ResponseDto<IEnumerable<OrderDto>>> GetAllAsync(DateTime startDate, DateTime endDate);
    Task<ResponseDto<OrderDto>> AddAsync(OrderCreateDto orderCreateDto);
    Task<ResponseDto<NoContent>> UpdateOrderStatusAsync(int id, OrderStatus orderStatus);
    Task<ResponseDto<NoContent>> CancelOrderAsync(int id);
}
