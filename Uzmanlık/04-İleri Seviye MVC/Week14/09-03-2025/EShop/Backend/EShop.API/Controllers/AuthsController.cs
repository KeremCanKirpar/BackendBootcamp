using EShop.Services.Abstract;
using EShop.Shared.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    // uygulamaadresi/api/auths
    // bu şekilde bir rota belirlediğimizde, bu adrese;
    // POST metodu ile bir istek geldiğinde HttpPost tipindeki metot(Login) çalışacak
    // GET metodu ile bir istek geldiğinde HttpGet tipindeki metot(???) çalışacak
    // PUT metodu ile bir istek geldiğinde HttpPut tipindeki metot(???) çalışacak
    // DELETE metodu ile bir istek geldiğinde HttpDelete tipindeki metot(???) çalışacak
    [Route("api/auths")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
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

        [HttpPost("pass/change")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var response = await _authService.ChangePasswordAsync(changePasswordDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("pass/forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var response = await _authService.ForgotPasswordAsync(forgotPasswordDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("pass/reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var response = await _authService.ResetPasswordAsync(resetPasswordDto);
            return StatusCode(response.StatusCode, response);
        }

    }
}
