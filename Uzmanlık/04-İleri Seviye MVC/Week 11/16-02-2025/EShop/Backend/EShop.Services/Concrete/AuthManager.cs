using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Configurations.Auth;
using EShop.Shared.Dtos;
using EShop.Shared.Dtos.Auth;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Services.Concrete;

public class AuthManager : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailService _emailManager;
    private JwtConfig _jwtConfig;
    //Aslında burada başka servisler de olacak, ancak henüz yazmadık.
    public AuthManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtConfig> options, IEmailService emailManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtConfig = options.Value;
        _emailManager = emailManager;
    }

    public async Task<ResponseDto<NoContent>> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(changePasswordDto.UserName!);
            if (user == null)
            {
                return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı!", StatusCodes.Status404NotFound);
            }
            var isValidPassword = await _userManager.CheckPasswordAsync(user, changePasswordDto.CurrentPassword!);
            if (!isValidPassword)
            {
                return ResponseDto<NoContent>.Fail("Mevcut şifre hatalı!", StatusCodes.Status400BadRequest);
            }
            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword!, changePasswordDto.NewPassword!);
            if (!result.Succeeded)
            {
                return ResponseDto<NoContent>.Fail(
                    result.Errors.Select(x => x.Description).ToList(), StatusCodes.Status400BadRequest
                );
            }
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }



    public async Task<ResponseDto<TokenDto>> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName!);
            if (user == null)
            {
                return ResponseDto<TokenDto>.Fail("Kullanıcı adı veya şifre hatalı", StatusCodes.Status400BadRequest);
            }
            var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password!);
            if (!isValidPassword)
            {
                return ResponseDto<TokenDto>.Fail("Kullanıcı adı veya şifre hatalı", StatusCodes.Status400BadRequest);
            }
            var tokenDto = await GenerateJwtToken(user);
            return ResponseDto<TokenDto>.Success(tokenDto, StatusCodes.Status200OK);

        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Giriş yapılırken bir hata oluştu: {ex.Message}");
            throw;
        }
    }

    public async Task<ResponseDto<ApplicationUserDto>> RegisterAsync(RegisterDto registerDto)
    {
        try
        {
            var existingUser = await _userManager.FindByNameAsync(registerDto.UserName);
            if (existingUser != null)
            {
                return ResponseDto<ApplicationUserDto>.Fail("Bu kullanıcı adı zaten kullanılmakta", StatusCodes.Status400BadRequest);
            }
            var user = new ApplicationUser(
                firstName: registerDto.FirstName,
                lastName: registerDto.LastName,
                dateOfBirth: registerDto.DateOfBirth,
                gender: registerDto.Gender
            )
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                EmailConfirmed = true,
                Address = registerDto.Address,
                City = registerDto.City
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return ResponseDto<ApplicationUserDto>.Fail("Kullanıcı oluşturulurken bir hata oluştu", StatusCodes.Status400BadRequest);
            }
            result = await _userManager.AddToRoleAsync(user, registerDto.Role);
            if (!result.Succeeded)
            {
                return ResponseDto<ApplicationUserDto>.Fail("Kullanıcı rolü atanırken bir hata oluştu", StatusCodes.Status400BadRequest);
            }
            var userDto = new ApplicationUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                City = user.City
            };
            return ResponseDto<ApplicationUserDto>.Success(userDto, StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kayıt olunurken bir hata oluştu: {ex.Message}");
            throw;
        }
    }

    public async Task<ResponseDto<NoContent>> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email!);
            if (user == null)
            {
                return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı!", StatusCodes.Status404NotFound);
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //http://localhost:5220/auth/resetpassword?token=sfhsadhj4+^%+^%+ETRsdfjksdfdsahfasdhfdsalfhdslkjfhdsajhdsalfjk&email=aysefatma@gmail.com
            var resetLink = $"http://localhost:5220/auth/resetpassword?token={token}&email={forgotPasswordDto.Email}";
            var htmlBody = $"<p>Şifrenizi değiştirmek için aşağıdaki linke tıklayınız:</p><a href='{resetLink}'>Şifremi Değiştir</a>";
            var response = await _emailManager.SendEmailAsync(
                forgotPasswordDto.Email!,
                "EShop Şifre Sıfırlama Talebi",
                htmlBody
            );
            if (!response.IsSuccessful)
            {
                return ResponseDto<NoContent>.Fail(response.Error!, response.StatusCode);
            }
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDto<NoContent>> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email!);
            if (user == null)
            {
                return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı!", StatusCodes.Status404NotFound);
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token!, resetPasswordDto.Password!);
            if (!result.Succeeded)
            {
                return ResponseDto<NoContent>.Fail("Şifre sıfırlama sırasında bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
        }

        catch (Exception ex)
        {
           return ResponseDto<NoContent>.Fail(ex.Message,StatusCodes.Status500InternalServerError);

        }
    }

    private async Task<TokenDto> GenerateJwtToken(ApplicationUser user)
    {
        try
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToDouble(_jwtConfig.AccessTokenExpiration));

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: expiry,
                signingCredentials: credentials
            );
            var tokenDto = new TokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                AccessTokenExpirationDate = expiry
            };
            return tokenDto;

        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Token oluşturulurken bir hata oluştu: {ex.Message}");
            throw;
        }
    }
}



// foreach (var role in roles)
// {
//     claims.Add(new Claim(ClaimTypes.Role, role));
// }