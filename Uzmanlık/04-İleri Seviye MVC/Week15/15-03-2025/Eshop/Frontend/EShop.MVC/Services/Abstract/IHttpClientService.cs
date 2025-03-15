using System.Text.Json;
using System.Net.Http;

namespace EShop.MVC.Services.Abstract;

public interface IHttpClientService
{
    Task<TResponse?> GetAsync<TResponse>(string endpoint, Dictionary<string, string>? queryParams = null);
    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request);
    Task<TResponse?> PostFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData);
    Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request);
    Task<TResponse?> PutFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData);
    Task<TResponse?> DeleteAsync<TResponse>(string endpoint);
}