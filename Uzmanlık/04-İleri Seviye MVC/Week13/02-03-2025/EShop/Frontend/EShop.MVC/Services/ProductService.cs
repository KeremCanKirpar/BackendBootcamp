using System;
using EShop.MVC.Areas.Admin.Models;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;

namespace EShop.MVC.Services
{
    public class ProductService : IProductService
    {

        private readonly IHttpClientService _httpClientService;

        public ProductService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResponseModel<ProductModel>> CreateAsync(ProductCreateModel productCreateModel)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(productCreateModel.Name!),"Name");
            formData.Add(new StringContent(productCreateModel.Properties!),"Properties");
            formData.Add(new StringContent(productCreateModel.Price?.ToString()!),"Price");
            foreach(var categoryId in productCreateModel.CategoryIds)
            {
                formData.Add(new StringContent(categoryId.ToString()),"CategoryIds");
            }
            StreamContent streamContent;
            if(productCreateModel.Image != null)
            {
                 streamContent = new StreamContent(productCreateModel.Image.OpenReadStream());
                
            }
            else
            {
                // Varsayılan Resmi Gönder
                var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(),"wwroot","images","no-image.png");
                 streamContent = new StreamContent(File.OpenRead(defaultImagePath));
            }
            formData.Add(streamContent, "Image", productCreateModel.Image!.FileName);
            var response = await _httpClientService.PostFormAsync<ResponseModel<ProductModel>>("products",formData);
            return response!;
        }

        public Task<ResponseModel<List<ProductModel>>> GetAllActivesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductModel>>> GetAllDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProductModel>> GetByIdAsync(int id)
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

        public Task<ResponseModel<ProductModel>> UpdateAsync(ProductUpdateModel productUpdateModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<NoContent>> UpdateIsActiveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
