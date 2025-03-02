using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Shared.Dtos.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Şifre boş bırakılamaz")]
    public string? Password { get; set; }
}
