using System;

namespace EShop.MVC.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<TResponse?> GetAsync<TResponse>(string endpoint);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request);
        Task<TResponse?> PostFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request);
        Task<TResponse?> PutFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData);
        Task<TResponse?> DeleteAsync<TResponse>(string endpoint);
    }
}
