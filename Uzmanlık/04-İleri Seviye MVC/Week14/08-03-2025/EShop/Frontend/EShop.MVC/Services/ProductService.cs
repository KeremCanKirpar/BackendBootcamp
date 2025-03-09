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
            formData.Add(new StringContent(productCreateModel.Name!), "Name");
            formData.Add(new StringContent(productCreateModel.Properties!), "Properties");
            formData.Add(new StringContent(productCreateModel.Price?.ToString()!), "Price");
            foreach (var categoryId in productCreateModel.CategoryIds)
            {
                formData.Add(new StringContent(categoryId.ToString()), "CategoryIds");
            }
            StreamContent streamContent;
            string imageFileName;
            if (productCreateModel.Image != null)
            {
                streamContent = new StreamContent(productCreateModel.Image.OpenReadStream());
                imageFileName=productCreateModel.Image.FileName;
            }
            else
            {
                //Varsayılan resmi gönder
                var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "no-image.png");
                streamContent = new StreamContent(File.OpenRead(defaultImagePath));
                imageFileName="no-image.png";
            }

            formData.Add(streamContent, "Image", imageFileName);
            var response = await _httpClientService.PostFormAsync<ResponseModel<ProductModel>>("products", formData);
            return response!;
        }

        public async Task<ResponseModel<List<ProductModel>>> GetAllActivesAsync(bool isActive = true)
        {
            var response = await _httpClientService.GetAsync<ResponseModel<List<ProductModel>>>($"products/get/all/active?isActive={isActive}");
            return response!;
        }

        public async Task<ResponseModel<List<ProductModel>>> GetAllAsync()
        {
            var response = await _httpClientService.GetAsync<ResponseModel<List<ProductModel>>>($"products/get/all");
            return response!;
        }

        public async Task<ResponseModel<List<ProductModel>>> GetAllDeletedAsync()
        {
            var response = await _httpClientService.GetAsync<ResponseModel<List<ProductModel>>>($"products/get/all/deleted");
            return response!;
        }

        public async Task<ResponseModel<ProductModel>> GetByIdAsync(int id)
        {
            var response = await _httpClientService.GetAsync<ResponseModel<ProductModel>>($"products/get/withcategories/{id}");
            return response!;
        }

        public async Task<ResponseModel<NoContent>> HardDeleteAsync(int id)
        {
            var response = await _httpClientService.DeleteAsync<ResponseModel<NoContent>>($"products/harddelete/{id}");
            return response!;
        }

        public async Task<ResponseModel<NoContent>> SoftDeleteAsync(int id)
        {
            var response = await _httpClientService.DeleteAsync<ResponseModel<NoContent>>($"products/softdelete/{id}");
            return response!;
        }

        public async Task<ResponseModel<ProductModel>> UpdateAsync(ProductUpdateModel productUpdateModel)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(productUpdateModel.Id!.ToString()), "Id");
            formData.Add(new StringContent(productUpdateModel.Name!), "Name");
            formData.Add(new StringContent(productUpdateModel.Properties!), "Properties");
            formData.Add(new StringContent(productUpdateModel.Price?.ToString()!), "Price");
            formData.Add(new StringContent(productUpdateModel.IsActive.ToString()!), "IsActive");
            formData.Add(new StringContent(productUpdateModel.IsDeleted.ToString()!), "IsDeleted");
            foreach (var categoryId in productUpdateModel.CategoryIds)
            {
                formData.Add(new StringContent(categoryId.ToString()), "CategoryIds");
            }
            if (productUpdateModel.Image != null)
            {
                var streamContent = new StreamContent(productUpdateModel.Image.OpenReadStream());
                formData.Add(streamContent, "Image", productUpdateModel.Image!.FileName);
            }

            var response = await _httpClientService.PutFormAsync<ResponseModel<ProductModel>>("products", formData);
            return response!;
        }

        public async Task<ResponseModel<NoContent>> UpdateIsActiveAsync(int id)
        {
            var response = await _httpClientService.PutAsync<object, ResponseModel<NoContent>>($"products/updateisactive/{id}", null!);
            return response!;
        }
    }
}
