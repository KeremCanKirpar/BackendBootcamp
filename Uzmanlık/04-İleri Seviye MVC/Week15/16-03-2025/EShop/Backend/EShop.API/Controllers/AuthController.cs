using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.AuthDtos;
using EShop.Shared.Dtos.ResponseDtos;
using EShop.Shared.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmAccount(ConfirmAccountDto confirmAccountDto)
        {
            var result = await _authService.ConfirmAccountAsync(confirmAccountDto);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            changePasswordDto.ApplicationUserId = GetUserId();
            var response = await _authService.ChangePasswordAsync(changePasswordDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("users/password-reset-request")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var response = await _authService.ForgotPasswordAsync(forgotPasswordDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("users/password-reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var response = await _authService.ResetPasswordAsync(resetPasswordDto);
            return StatusCode(response.StatusCode, response);
        }

        [Authorize]
        [HttpGet("users/me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var response = await _userService.GetByIdAsync(GetUserId());
            return CreateResult(response);
        }

        [Authorize]
        [HttpPut("users/me")]
        public async Task<IActionResult> UpdateMyProfile([FromForm] UserUpdateDto userUpdateDto)
        {
            userUpdateDto.Id = GetUserId();
            var response = await _userService.UpdateAsync(userUpdateDto);
            return CreateResult(response);
        }
    }
}
