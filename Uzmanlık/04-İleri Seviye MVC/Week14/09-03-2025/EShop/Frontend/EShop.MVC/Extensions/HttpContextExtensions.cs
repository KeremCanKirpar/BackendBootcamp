using System;

namespace EShop.MVC.Extensions
{
    public static class HttpContextExtensions
    {
        private static string? _apiBaseUrl;
        public static string GetApiBaseUrl(this HttpContext httpContext)
        {
            if(_apiBaseUrl == null)
            {
                var configuration = httpContext.RequestServices.GetRequiredService<IConfiguration>();
                _apiBaseUrl = configuration.GetSection("ApiSettings:BaseUri").Value!;
            }
            return _apiBaseUrl;
        }
    }
}
