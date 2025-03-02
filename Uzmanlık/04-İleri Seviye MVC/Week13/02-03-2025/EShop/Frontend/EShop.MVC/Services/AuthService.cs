using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EShop.MVC.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpClientService httpClientService, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientService = httpClientService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<TokenModel>> LoginAsync(LoginModel loginModel)
        {
            var response = await _httpClientService.PostAsync<LoginModel, ResponseModel<TokenModel>>("auths/login", loginModel);
            // eğer başarılı bir şekilde login olunmuşsa
            if (response?.IsSuccessful == true && response.Data != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(response.Data.AccessToken);
                var claims = new List<Claim>();
                claims.AddRange(jwtToken.Claims);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = response.Data.AccessTokenExpirationDate,
                    Items ={
                        {"access-token",response.Data.AccessToken}
                    }
                };
                await _httpContextAccessor.HttpContext!.SignInAsync(
                    scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                    principal: new ClaimsPrincipal(claimsIdentity),
                    properties: authProperties
                );
            }
            return response!;
        }

        public async Task<ResponseModel<NoContent>> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            var response = await _httpClientService.PostAsync<ChangePasswordModel, ResponseModel<NoContent>>("auths/pass/change", changePasswordModel);
            return response!;
        }

        public async Task<ResponseModel<NoContent>> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
        {
            var response = await _httpClientService.PostAsync<ForgotPasswordModel, ResponseModel<NoContent>>("auths/pass/forgot", forgotPasswordModel);
            return response!;
        }


        public async Task LogoutAsync()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<ResponseModel<NoContent>> RegisterAsync(RegisterModel registerModel)
        {
            var response = await _httpClientService.PostAsync<RegisterModel, ResponseModel<NoContent>>("auths/register", registerModel);
            return response!;
        }

        public async Task<ResponseModel<NoContent>> ResetPasswordAsync(ResetPasswordModel resetPasswordModel)
        {
            var response = await _httpClientService.PostAsync<ResetPasswordModel, ResponseModel<NoContent>>("auths/pass/reset", resetPasswordModel);
            return response!;
        }
    }
}
