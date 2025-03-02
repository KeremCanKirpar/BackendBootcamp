using System;
using EShop.MVC.Models;

namespace EShop.MVC.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseModel<TokenModel>> LoginAsync(LoginModel loginModel);
        Task<ResponseModel<NoContent>> RegisterAsync(RegisterModel registerModel);
        Task<ResponseModel<NoContent>> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel);
        Task<ResponseModel<NoContent>> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
        Task<ResponseModel<NoContent>> ChangePasswordAsync(ChangePasswordModel changePasswordModel);
        Task LogoutAsync();
    }
}
