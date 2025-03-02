using System;
using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;

namespace EShop.MVC.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("API");
    }

    public Task<ResponseModel<int>> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<int>> CountAsync(bool isActive)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<ProductModel>> CreateProductAsync(ProductCreateModel productCreateModel)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<List<ProductModel>>> GetAllActivesAsync()
    {
        var httpResponseMessage =  await _client.GetAsync("products");
        var contentResponse =  await httpResponseMessage.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<ResponseModel<List<ProductModel>>>(contentResponse);
        return response;
    }

    public Task<ResponseModel<List<ProductModel>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<ProductModel>>> GetAllPassivesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<ProductModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<NoContent>> HardDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<NoContent>> SoftDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<bool>> UpdateIsActive(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<ProductModel>> UpdateProductAsync(ProductUpdateModel productUpdateModel)
    {
        throw new NotImplementedException();
    }
}
