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


    }
}
