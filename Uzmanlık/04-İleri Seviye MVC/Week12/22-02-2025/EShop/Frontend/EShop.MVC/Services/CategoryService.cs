using System;
using System.Net.Http;
using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace EShop.MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(IHttpClientFactory clientFactory)
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

        public Task<ResponseModel<CategoryModel>> CreateAsync(CategoryCreateModel categoryCreateModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<CategoryModel>>> GetAllActivesAsync()
        {
            var httpResponseMessage = await _client.GetAsync("categories");
            var contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel<List<CategoryModel>>>(contentResponse);
            return response;
        }

        public Task<ResponseModel<List<CategoryModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CategoryModel>>> GetAllPassivesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CategoryModel>> GetAsync(int id)
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

        public Task<ResponseModel<NoContent>> UpdateAsync(CategoryUpdateModel categoryUpdateModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> UpdateIsActive(int id)
        {
            throw new NotImplementedException();
        }
    }
}
