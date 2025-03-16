using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace EShop.MVC.Services.Concrete;

public class ProductService : IProductService
{
    private readonly IHttpClientService _httpClientService;

    public ProductService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<ResponseModel<List<ProductModel>>> GetAllAdminAsync(bool? isActive = null, bool? includeCategories = null, int? categoryId = null, bool? isDeleted = null)
    {
        try
        {
            var queryParams = new Dictionary<string, string>();
            if (isDeleted.HasValue) queryParams.Add("isDeleted", isDeleted.ToString()!);
            if (includeCategories.HasValue) queryParams.Add("includeCategories", includeCategories.ToString()!);
            if (categoryId.HasValue) queryParams.Add("categoryId", categoryId.ToString()!);
            if (isActive.HasValue) queryParams.Add("isActive", isActive.ToString()!);

            var response = await _httpClientService.GetAsync<ResponseModel<List<ProductModel>>>("products/admin", queryParams);
            return response ?? new ResponseModel<List<ProductModel>>
            {
                Data = new List<ProductModel>(),
                Error = "Sunucudan yanıt alınamadı.",
                IsSuccessful = false
            };
        }
        catch (HttpRequestException ex)
        {
            return new ResponseModel<List<ProductModel>>
            {
                Data = new List<ProductModel>(),
                Error = ex.Message,
                IsSuccessful = false
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<List<ProductModel>>
            {
                Data = new List<ProductModel>(),
                Error = "Beklenmeyen bir hata oluştu: " + ex.Message,
                IsSuccessful = false
            };
        }
    }

    public async Task<ResponseModel<List<ProductModel>>> GetAllAsync()
    {
        try
        {
            var response = await _httpClientService.GetAsync<ResponseModel<List<ProductModel>>>("products");
            return response ?? new ResponseModel<List<ProductModel>>
            {
                Data = new List<ProductModel>(),
                Error = "Sunucudan yanıt alınamadı.",
                IsSuccessful = false
            };
        }
        catch (HttpRequestException ex)
        {
            return new ResponseModel<List<ProductModel>>
            {
                Data = new List<ProductModel>(),
                Error = ex.Message,
                IsSuccessful = false
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<List<ProductModel>>
            {
                Data = new List<ProductModel>(),
                Error = "Beklenmeyen bir hata oluştu: " + ex.Message,
                IsSuccessful = false
            };
        }
    }

    public async Task<ResponseModel<ProductModel>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClientService.GetAsync<ResponseModel<ProductModel>>($"products/{id}?includeCategories=true");
            return response ?? new ResponseModel<ProductModel>
            {
                Data = null,
                Error = "Sunucudan yanıt alınamadı.",
                IsSuccessful = false
            };
        }
        catch (HttpRequestException ex)
        {
            return new ResponseModel<ProductModel>
            {
                Data = null,
                Error = ex.Message,
                IsSuccessful = false
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<ProductModel>
            {
                Data = null,
                Error = "Beklenmeyen bir hata oluştu: " + ex.Message,
                IsSuccessful = false
            };
        }
    }

    public async Task<ResponseModel<ProductModel>> CreateAsync(ProductCreateModel model)
    {
        try
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(model.Name ?? string.Empty), "Name");
            formData.Add(new StringContent(model.Properties ?? string.Empty), "Properties");
            formData.Add(new StringContent(model.Price?.ToString() ?? "0"), "Price");
            formData.Add(new StringContent(model.IsHome.ToString()), "IsActive");
            foreach (var categoryId in model.CategoryIds)
            {
                formData.Add(new StringContent(categoryId.ToString()), "CategoryIds");
            }
            if (model.Image != null)
            {
                var imageContent = new StreamContent(model.Image.OpenReadStream());
                formData.Add(imageContent, "Image", model.Image.FileName);
            }
            else
            {
                // Varsayılan resim dosyasını gönder
                var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "no-image.png");
                var imageContent = new StreamContent(File.OpenRead(defaultImagePath));
                formData.Add(imageContent, "Image", "no-image.png");
            }

            var response = await _httpClientService.PostFormAsync<ResponseModel<ProductModel>>("products", formData);
            return response ?? new ResponseModel<ProductModel>
            {
                Data = null,
                Error = "Sunucudan yanıt alınamadı.",
                IsSuccessful = false
            };
        }
        catch (HttpRequestException ex)
        {
            return new ResponseModel<ProductModel>
            {
                Data = null,
                Error = ex.Message,
                IsSuccessful = false
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<ProductModel>
            {
                Data = null,
                Error = "Beklenmeyen bir hata oluştu: " + ex.Message,
                IsSuccessful = false
            };
        }
    }

    public async Task<ResponseModel<ProductModel>> UpdateAsync(ProductUpdateModel model)
    {
        try
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(model.Id.ToString()), "Id");
            formData.Add(new StringContent(model.Name ?? string.Empty), "Name");
            formData.Add(new StringContent(model.Properties ?? string.Empty), "Properties");
            formData.Add(new StringContent(model.Price?.ToString() ?? "0"), "Price");
            formData.Add(new StringContent(model.IsHome.ToString()), "IsHome");
            foreach (var categoryId in model.CategoryIds)
            {
                formData.Add(new StringContent(categoryId.ToString()), "CategoryIds");
            }
            if (model.Image != null)
            {
                var imageContent = new StreamContent(model.Image.OpenReadStream());
                formData.Add(imageContent, "Image", model.Image.FileName);
            }

            var response = await _httpClientService.PutFormAsync<ResponseModel<ProductModel>>($"products/{model.Id}", formData);
            return response ?? new ResponseModel<ProductModel>
            {
                Data = null,
                Error = "Sunucudan yanıt alınamadı.",
                IsSuccessful = false
            };
        }
        catch (HttpRequestException ex)
        {
            return new ResponseModel<ProductModel>
            {
                Data = null,
                Error = ex.Message,
                IsSuccessful = false
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel<ProductModel>
            {
                Data = null,
                Error = "Beklenmeyen bir hata oluştu: " + ex.Message,
                IsSuccessful = false
            };
        }
    }

    public async Task<ResponseModel<NoContent>> SoftDeleteAsync(int id)
    {
        try
        {
            var response = await _httpClientService.PutAsync<object, ResponseModel<NoContent>>($"products/{id}/status", null!);
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
            var response = await _httpClientService.DeleteAsync<ResponseModel<NoContent>>($"products/{id}");
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

    public async Task<ResponseModel<NoContent>> UpdateIsActiveAsync(int id)
    {
        try
        {
            var response = await _httpClientService.PutAsync<object, ResponseModel<bool>>($"products/{id}/active", null!);

            return new ResponseModel<NoContent>
            {
                Data = response!.IsSuccessful ? new NoContent() : null,
                Error = response.Error,
                IsSuccessful = response.IsSuccessful
            };
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

    public async Task<ResponseModel<NoContent>> UpdateIsHomeAsync(int id)
    {
        try
        {
            var response = await _httpClientService.PutAsync<object, ResponseModel<bool>>($"products/{id}/home", null!);

            return new ResponseModel<NoContent>
            {
                Data = response!.IsSuccessful ? new NoContent() : null,
                Error = response.Error,
                IsSuccessful = response.IsSuccessful
            };
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
}