using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using EShop.MVC.Configurations;
using Microsoft.Extensions.Options;

namespace EShop.MVC.Services.Concrete;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ApiSettings _apiSettings;

    public HttpClientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, ILogger<HttpClientService> logger, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        _apiSettings = apiSettings.Value;
        _httpClient.BaseAddress = new Uri(_apiSettings.BaseUri);
    }

    private async Task SetAuthorizationHeader(string endpoint)
    {
        // Önce tüm header'ları temizle
        _httpClient.DefaultRequestHeaders.Clear();

        var authResult = await _httpContextAccessor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var token = authResult.Properties?.Items["access_token"];

        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // Public endpoint'ler için API Key ekleme
        if (endpoint.StartsWith("auth/", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (!string.IsNullOrEmpty(_apiSettings.ApiKey) && _apiSettings.ApiKey != "not_set")
        {
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiSettings.ApiKey);
        }
    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint, Dictionary<string, string>? queryParams = null)
    {
        await SetAuthorizationHeader(endpoint);

        var baseUri = new Uri(_httpClient.BaseAddress!.ToString());
        var combinedUri = new Uri(baseUri, endpoint);

        var uriBuilder = new UriBuilder(combinedUri);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (queryParams != null)
        {
            foreach (var param in queryParams)
            {
                query[param.Key] = param.Value;
            }
        }

        uriBuilder.Query = query.ToString();
        string fullEndpoint = uriBuilder.Uri.ToString();

        var response = await _httpClient.GetAsync(fullEndpoint);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
        {
            return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
        }

        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
            return result;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialize hatası. Content: {responseContent}");
            Console.WriteLine(ex.Message);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
            }

            throw;
        }
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        await SetAuthorizationHeader(endpoint);

        var jsonContent = JsonSerializer.Serialize(request);
        var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(endpoint, stringContent);
        var responseContent = await response.Content.ReadAsStringAsync();

        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
            return result;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialize hatası. Content: {responseContent}");
            Console.WriteLine(ex.Message);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
            }

            throw;
        }
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        await SetAuthorizationHeader(endpoint);

        var jsonContent = JsonSerializer.Serialize(request);
        var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(endpoint, stringContent);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
        {
            return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
        }
        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
            return result;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialize hatası. Content: {responseContent}");
            Console.WriteLine(ex.Message);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
            }

            throw;
        }
    }

    public async Task<TResponse?> DeleteAsync<TResponse>(string endpoint)
    {
        await SetAuthorizationHeader(endpoint);

        var response = await _httpClient.DeleteAsync(endpoint);
        var responseContent = await response.Content.ReadAsStringAsync();

        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
            return result;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialize hatası. Content: {responseContent}");
            Console.WriteLine(ex.Message);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
            }

            throw;
        }
    }

    public async Task<TResponse?> PostFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData)
    {
        await SetAuthorizationHeader(endpoint);

        var response = await _httpClient.PostAsync(endpoint, formData);
        var responseContent = await response.Content.ReadAsStringAsync();

        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
            return result;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialize hatası. Content: {responseContent}");
            Console.WriteLine(ex.Message);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
            }

            throw;
        }
    }

    public async Task<TResponse?> PutFormAsync<TResponse>(string endpoint, MultipartFormDataContent formData)
    {
        await SetAuthorizationHeader(endpoint);

        var response = await _httpClient.PutAsync(endpoint, formData);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(responseContent) && response.IsSuccessStatusCode)
        {
            return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
        }

        try
        {
            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions);
            return result;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialize hatası. Content: {responseContent}");
            Console.WriteLine(ex.Message);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status: {response.StatusCode}, Message: {responseContent}");
            }

            throw;
        }
    }
}