using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EShop.MVC.Services.Concrete;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public HttpClientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, ILogger<HttpClientService> logger)
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
        var token = authResult.Properties?.Items["access_token"];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint, Dictionary<string, string>? queryParams = null)
    {
        await SetAuthorizationHeader();

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
        await SetAuthorizationHeader();

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
        await SetAuthorizationHeader();

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
        await SetAuthorizationHeader();

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
        await SetAuthorizationHeader();

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