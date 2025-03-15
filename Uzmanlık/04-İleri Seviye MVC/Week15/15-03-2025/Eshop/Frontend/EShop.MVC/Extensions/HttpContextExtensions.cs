using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace EShop.MVC.Extensions;

public static class HttpContextExtensions
{
    private static string? _apiBaseUrl;

    public static string GetApiBaseUrl(this HttpContext context)
    {
        if (_apiBaseUrl == null)
        {
            var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
            _apiBaseUrl = configuration.GetSection("ApiSettings:BaseUri").Value!;
        }
        return _apiBaseUrl;
    }

    public static async Task SetTokenAsync(this HttpContext context, string tokenName, string token)
    {
        var authInfo = await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (authInfo.Properties != null)
        {
            authInfo.Properties.StoreTokens(new[]
            {
                new AuthenticationToken
                {
                    Name = tokenName,
                    Value = token
                }
            });

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                authInfo.Principal!,
                authInfo.Properties);
        }
    }
}