using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EShop.MVC.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public HttpClientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        private async Task SetAuthorizationHeader()
        {
            var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var token = authResult.Properties?.Items["access-token"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                Console.WriteLine("Token bulunamadı!");//Loglama ile ilgili daha merkezi bir operasyon yapılabilir.
            }
        }

        public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
        {
            await SetAuthorizationHeader();
            var response = await _httpClient.GetAsync(endpoint);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
            {
                //API'dan başarılı ama içeriği boş bir yanıt döndüyse
                return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
            }
            try
            {
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
                return result;
            }
            catch (JsonException ex)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {response.Content}");
                }
                throw new Exception($"Hata: {ex.Message}");
            }
        }

        public async Task<TResponse?> DeleteAsync<TResponse>(string endpoint)
        {
            await SetAuthorizationHeader();
            var response = await _httpClient.DeleteAsync(endpoint);
            var responseContent = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
                return result;
            }
            catch (JsonException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            await SetAuthorizationHeader();
            var jsonContent = JsonSerializer.Serialize(request);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, stringContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
            {
                //API'dan başarılı ama içeriği boş bir yanıt döndüyse
                return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
            }
            try
            {
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
                return result;
            }
            catch (JsonException ex)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {response.Content}");
                }
                throw new Exception($"Hata: {ex.Message}");
            }
        }

        public async Task<TResponse?> PostFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData)
        {
            await SetAuthorizationHeader();

            var response = await _httpClient.PostAsync(endpoint, formData);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
            {
                //API'dan başarılı ama içeriği boş bir yanıt döndüyse
                return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
            }
            try
            {
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
                return result;
            }
            catch (JsonException ex)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {response.Content}");
                }
                throw new Exception($"Hata: {ex.Message}");
            }
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            await SetAuthorizationHeader();
            var jsonContent = JsonSerializer.Serialize(request);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(endpoint, stringContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
            {
                //API'dan başarılı ama içeriği boş bir yanıt döndüyse
                return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
            }
            try
            {
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
                return result;
            }
            catch (JsonException ex)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {response.Content}");
                }
                throw new Exception($"Hata: {ex.Message}");
            }
        }

        public async Task<TResponse?> PutFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData)
        {
            await SetAuthorizationHeader();

            var response = await _httpClient.PutAsync(endpoint, formData);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
            {
                //API'dan başarılı ama içeriği boş bir yanıt döndüyse
                return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
            }
            try
            {
                var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
                return result;
            }
            catch (JsonException ex)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Status: {response.StatusCode}, Message: {response.Content}");
                }
                throw new Exception($"Hata: {ex.Message}");
            }
        }
    }
}
