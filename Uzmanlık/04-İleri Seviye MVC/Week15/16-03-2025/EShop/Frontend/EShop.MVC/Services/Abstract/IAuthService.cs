using EShop.MVC.Models;

namespace EShop.MVC.Services.Abstract;

public interface IAuthService
{
    Task<ResponseModel<TokenModel>> LoginAsync(LoginModel model);
    Task<ResponseModel<NoContent>> RegisterAsync(RegisterModel model);
    Task<ResponseModel<NoContent>> ForgotPasswordAsync(ForgotPasswordModel model);
    Task<ResponseModel<NoContent>> ResetPasswordAsync(ResetPasswordModel model);
    Task<ResponseModel<NoContent>> ChangePasswordAsync(ChangePasswordModel model);
    Task<ResponseModel<bool>> ConfirmAccountAsync(ConfirmAccountModel confirmAccountModel);
    Task LogoutAsync();
}