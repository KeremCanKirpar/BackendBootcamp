using EShop.Data.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EShop.API.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_HEADER = "X-Api-Key";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, EShopDbContext dbContext)
        {
            var endpoint = context.Request.Path.Value?.ToLower();

            // Public endpoint'ler için API Key kontrolü yapma
            if (endpoint != null && (
                endpoint.Contains("/api/auth/") ||
                endpoint.Contains("/api/auth") ||
                endpoint.Contains("/api/apiclient") ||
                endpoint.EndsWith("/api/categories") && context.Request.Method == "GET"
            ))
            {
                await _next(context);
                return;
            }

            // API Key header'ını string olarak al
            var extractedApiKey = context.Request.Headers[API_KEY_HEADER].ToString();

            if (string.IsNullOrEmpty(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new { message = "API Key eksik!" });
                return;
            }

            var apiClient = await dbContext.ApiClients
                .FirstOrDefaultAsync(x => x.ApiKey == extractedApiKey && x.IsActive);

            if (apiClient == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new { message = "Geçersiz API Key!" });
                return;
            }

            // API kullanım istatistiklerini güncelle
            apiClient.LastUsedAt = DateTime.UtcNow;
            apiClient.RequestCount++;
            await dbContext.SaveChangesAsync();

            await _next(context);
        }
    }
}