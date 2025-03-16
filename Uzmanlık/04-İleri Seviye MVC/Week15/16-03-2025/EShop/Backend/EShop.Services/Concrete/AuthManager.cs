using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Configurations.Auth;
using EShop.Shared.Dtos.AuthDtos;
using EShop.Shared.Dtos.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Services.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICartService _cartService;
        private readonly IEmailService _emailManager;
        private JwtConfig _jwtConfig;
        private AppUrlConfig _appUrlConfig;

        public AuthManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtConfig> jwtOptions, IEmailService emailManager, IOptions<AppUrlConfig> appUrlOptions, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtOptions.Value;
            _emailManager = emailManager;
            _appUrlConfig = appUrlOptions.Value;
            _cartService = cartService;
        }

        public async Task<ResponseDto<NoContent>> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(changePasswordDto.ApplicationUserId!);
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
                        result.Errors.Select(x => x.Description).FirstOrDefault()!, StatusCodes.Status400BadRequest
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
                var user = await _userManager.FindByNameAsync(loginDto.UserNameOrEmail!)
                            ?? await _userManager.FindByEmailAsync(loginDto.UserNameOrEmail!);
                if (user == null)
                {
                    return ResponseDto<TokenDto>.Fail("Kullanıcı adı/Email veya şifre hatalı", StatusCodes.Status400BadRequest);
                }

                if (!user.EmailConfirmed)
                {
                    return ResponseDto<TokenDto>.Fail("Lütfen email adresinizi onaylayın. Onay emaili gelen kutunuzu kontrol edin.", StatusCodes.Status400BadRequest);
                }

                var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password!);
                if (!isValidPassword)
                {
                    return ResponseDto<TokenDto>.Fail("Kullanıcı adı/Email veya şifre hatalı", StatusCodes.Status400BadRequest);
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
                var existingUser = await _userManager.FindByNameAsync(registerDto.UserName!);
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
                    EmailConfirmed = false,
                    Address = registerDto.Address,
                    City = registerDto.City
                };
                var result = await _userManager.CreateAsync(user, registerDto.Password!);
                if (!result.Succeeded)
                {
                    return ResponseDto<ApplicationUserDto>.Fail("Kullanıcı oluşturulurken bir hata oluştu", StatusCodes.Status400BadRequest);
                }
                result = await _userManager.AddToRoleAsync(user, "User");
                if (!result.Succeeded)
                {
                    return ResponseDto<ApplicationUserDto>.Fail("Kullanıcı rolü atanırken bir hata oluştu", StatusCodes.Status400BadRequest);
                }

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = System.Web.HttpUtility.UrlEncode(token);
                var encodedEmail = System.Web.HttpUtility.UrlEncode(user.Email);
                var resetLink = $"http://localhost:5230/account/confirmaccount?token={encodedToken}&email={encodedEmail}";
                var htmlBody = $@"
                    <h2>EShop Hesap Onaylama</h2>
                    <p>Sayın {user.FirstName} {user.LastName},</p>
                    <p>Hesabınızı onaylamak için aşağıdaki butona tıklayınız:</p>
                    <a href='{resetLink}' style='display:inline-block;padding:10px 20px;background-color:#384aeb;color:white;text-decoration:none;border-radius:5px;margin:15px 0;'>Hesabımı Onayla</a>
                    <p>Bu link 24 saat geçerlidir.</p>
                    <p>Eğer bu işlemi siz yapmadıysanız, lütfen bu e-postayı dikkate almayınız.</p>";

                var response = await _emailManager.SendEmailAsync(
                    user.Email!,
                    "EShop Hesap Onay",
                    htmlBody
                );

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
                var user = await _userManager.FindByNameAsync(forgotPasswordDto.UserNameOrEmail!)
                                ?? await _userManager.FindByEmailAsync(forgotPasswordDto.UserNameOrEmail!);
                if (user == null)
                {
                    return ResponseDto<NoContent>.Fail("Kullanıcı bulunamadı!", StatusCodes.Status404NotFound);
                }
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetLink = $"{_appUrlConfig.Url}account/resetpassword?token={token}&email={user.Email}";
                var htmlBody = $"<p>Şifrenizi değiştirmek için aşağıdaki linke tıklayınız:</p><a href='{resetLink}'>Şifremi Değiştir</a>";
                var response = await _emailManager.SendEmailAsync(
                    user.Email!,
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
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token!, resetPasswordDto.NewPassword!);
                if (!result.Succeeded)
                {
                    return ResponseDto<NoContent>.Fail("Şifre sıfırlama sırasında bir sorun oluştu!", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }

            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);

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
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }.Union(roles.Select(x => new Claim(ClaimTypes.Role, x)));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret!));
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

        public async Task<ResponseDto<bool>> ConfirmAccountAsync(ConfirmAccountDto confirmAccountDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(confirmAccountDto.Email!);
                if (user == null)
                {
                    return ResponseDto<bool>.Fail("Kullanıcı bulunamadı!", StatusCodes.Status404NotFound);
                }

                if (user.EmailConfirmed)
                {
                    return ResponseDto<bool>.Fail("Bu hesap zaten onaylanmış!", StatusCodes.Status400BadRequest);
                }

                var result = await _userManager.ConfirmEmailAsync(user, confirmAccountDto.Token!);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return ResponseDto<bool>.Fail($"Email onayı sırasında bir sorun oluştu: {errors}", StatusCodes.Status500InternalServerError);
                }
                await _cartService.CreateCartAsync(user.Id);

                return ResponseDto<bool>.Success(true, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<bool>.Fail($"Beklenmeyen bir hata oluştu: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
