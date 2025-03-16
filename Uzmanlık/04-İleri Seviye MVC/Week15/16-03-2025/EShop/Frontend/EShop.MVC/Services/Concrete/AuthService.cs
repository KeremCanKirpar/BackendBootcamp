using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EShop.MVC.Extensions;
using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

namespace EShop.MVC.Services.Concrete;

public class AuthService : IAuthService
{
    private readonly IHttpClientService _httpClientService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IHttpClientService httpClientService, IHttpContextAccessor httpContextAccessor, ILogger<AuthService> logger)
    {
        _httpClientService = httpClientService;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public async Task<ResponseModel<TokenModel>> LoginAsync(LoginModel model)
    {
        var response = await _httpClientService.PostAsync<LoginModel, ResponseModel<TokenModel>>("auth/login", model);

        if (response?.IsSuccessful == true && response.Data != null)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(response.Data.AccessToken);

            var claims = new List<Claim>();
            claims.AddRange(jwtToken.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = response.Data.AccessTokenExpirationDate,
                Items =
                {
                    { "access_token", response.Data.AccessToken }
                }
            };

            _logger.LogInformation("Setting access_token: {Token}", response.Data.AccessToken);

            await _httpContextAccessor.HttpContext!.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            _logger.LogInformation("Token set successfully");
        }

        return response!;
    }

    public async Task<ResponseModel<NoContent>> RegisterAsync(RegisterModel model)
    {
        var response = await _httpClientService.PostAsync<RegisterModel, ResponseModel<NoContent>>("auth/register", model);
        return response!;
    }

    public async Task<ResponseModel<NoContent>> ForgotPasswordAsync(ForgotPasswordModel model)
    {
        var response = await _httpClientService.PostAsync<ForgotPasswordModel, ResponseModel<NoContent>>("auth/forgot-password", model);
        return response!;
    }

    public async Task<ResponseModel<NoContent>> ResetPasswordAsync(ResetPasswordModel model)
    {
        var response = await _httpClientService.PostAsync<ResetPasswordModel, ResponseModel<NoContent>>("auth/users/password-reset", model);
        return response!;
    }

    public async Task<ResponseModel<NoContent>> ChangePasswordAsync(ChangePasswordModel model)
    {
        var response = await _httpClientService.PutAsync<ChangePasswordModel, ResponseModel<NoContent>>("auth/password", model);
        return response ?? new ResponseModel<NoContent> { Error = "Sunucudan yanıt alınamadı." };
    }

    public async Task LogoutAsync()
    {
        await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public async Task<ResponseModel<bool>> ConfirmAccountAsync(ConfirmAccountModel confirmAccountModel)
    {
        var response = await _httpClientService.PostAsync<ConfirmAccountModel, ResponseModel<bool>>("auth/confirm", confirmAccountModel);
        return response ?? new ResponseModel<bool> { Error = "Sunucudan yanıt alınamadı." };
    }
}