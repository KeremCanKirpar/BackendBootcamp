using Microsoft.AspNetCore.Mvc;
using EShop.MVC.Extensions;

namespace EShop.MVC.Helpers;

public static class UrlHelpers
{
    public static string ApiContent(this IUrlHelper urlHelper, string? path)
    {
        if (string.IsNullOrEmpty(path))
            return string.Empty;

        var baseUrl = urlHelper.ActionContext.HttpContext.GetApiBaseUrl().TrimEnd('/');
        baseUrl = baseUrl.EndsWith("/api") ? baseUrl[..^4] : baseUrl;
        return $"{baseUrl}/{path.TrimStart('/')}";
    }
}