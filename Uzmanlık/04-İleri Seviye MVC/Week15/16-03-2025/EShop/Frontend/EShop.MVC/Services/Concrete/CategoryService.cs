using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using System.Net.Http;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace EShop.MVC.Services.Concrete;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientService _httpClientService;

    public CategoryService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<ResponseModel<List<CategoryModel>>> GetAllAsync()
    {
        var response = await _httpClientService.GetAsync<ResponseModel<List<CategoryModel>>>("categories");
        return response!;
    }

    public async Task<ResponseModel<List<CategoryModel>>> GetAllAdminAsync(bool? isActive = null, bool? isDeleted = null)
    {
        var queryParams = new Dictionary<string, string>();
        if (isActive.HasValue) queryParams.Add("isActive", isActive.ToString()!);
        if (isDeleted.HasValue) queryParams.Add("isDeleted", isDeleted.ToString()!);
        var response = await _httpClientService.GetAsync<ResponseModel<List<CategoryModel>>>($"categories/admin", queryParams);
        return response!;
    }

    public async Task<ResponseModel<CategoryModel>> GetByIdAsync(int id)
    {
        var response = await _httpClientService.GetAsync<ResponseModel<CategoryModel>>($"categories/{id}");
        return response!;
    }

    public async Task<ResponseModel<CategoryModel>> CreateAsync(CategoryCreateModel model)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(model.Name!), "Name");
        if (!string.IsNullOrEmpty(model.Description))
            formData.Add(new StringContent(model.Description), "Description");
        if (model.Image != null)
        {
            var imageContent = new StreamContent(model.Image.OpenReadStream());
            formData.Add(imageContent, "Image", model.Image.FileName);
        }
        else
        {
            var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "no-image.png");
            var imageContent = new StreamContent(File.OpenRead(defaultImagePath));
            formData.Add(imageContent, "Image", "no-image.png");
        }

        var response = await _httpClientService.PostFormAsync<ResponseModel<CategoryModel>>("categories", formData);
        return response!;
    }

    public async Task<ResponseModel<CategoryModel>> UpdateAsync(CategoryUpdateModel model)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(model.Id.ToString()), "Id");
        formData.Add(new StringContent(model.Name), "Name");
        if (!string.IsNullOrEmpty(model.Description))
            formData.Add(new StringContent(model.Description), "Description");
        formData.Add(new StringContent(model.IsActive.ToString()), "IsActive");
        formData.Add(new StringContent(model.IsMenuItem.ToString()), "IsMenuItem");
        if (model.Image != null)
        {
            var imageContent = new StreamContent(model.Image.OpenReadStream());
            formData.Add(imageContent, "Image", model.Image.FileName);
        }

        var response = await _httpClientService.PutFormAsync<ResponseModel<CategoryModel>>($"categories/{model.Id}", formData);
        return response!;
    }

    public async Task<ResponseModel<NoContent>> SoftDeleteAsync(int id)
    {
        try
        {
            var response = await _httpClientService.PutAsync<object, ResponseModel<NoContent>>($"categories/{id}/status", null!);
            Console.WriteLine("CEVAP: " + response);
            return response!;
        }
        catch (HttpRequestException ex)
        {
            return new ResponseModel<NoContent>
            {
                Data = null,
                Error = ex.Message,
                IsSuccessful = false
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<NoContent>
            {
                Data = null,
                Error = "Beklenmeyen bir hata oluştu: " + ex.Message,
                IsSuccessful = false
            };
        }
    }

    public async Task<ResponseModel<NoContent>> HardDeleteAsync(int id)
    {
        try
        {
            var response = await _httpClientService.DeleteAsync<ResponseModel<NoContent>>($"categories/{id}");
            return response!;
        }
        catch (HttpRequestException ex)
        {
            return new ResponseModel<NoContent>
            {
                Data = null,
                Error = ex.Message,
                IsSuccessful = false
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<NoContent>
            {
                Data = null,
                Error = "Beklenmeyen bir hata oluştu: " + ex.Message,
                IsSuccessful = false
            };
        }
    }

    public async Task<ResponseModel<bool>> UpdateIsActiveAsync(int id)
    {
        var response = await _httpClientService.PutAsync<object, ResponseModel<bool>>($"categories/{id}/active", null!);
        return response!;
    }

    public async Task<ResponseModel<bool>> UpdateIsMenuItemAsync(int id)
    {
        var response = await _httpClientService.PutAsync<object, ResponseModel<bool>>($"categories/{id}/menuitem", null!);
        return response!;
    }

    public async Task<ResponseModel<List<CategoryModel>>> GetMenuItemsAsync()
    {
        var response = await _httpClientService.GetAsync<ResponseModel<List<CategoryModel>>>("categories/admin/menuitems");
        return response!;
    }
}