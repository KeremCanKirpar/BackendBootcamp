using System;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.Auth;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface IAuthService
{
    Task<ResponseDto<TokenDto>> LoginAsync(LoginDto loginDto);
    Task<ResponseDto<ApplicationUserDto>> RegisterAsync(RegisterDto registerDto);
    Task<ResponseDto<NoContent>> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
    Task<ResponseDto<NoContent>> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
    Task<ResponseDto<NoContent>> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);

}
