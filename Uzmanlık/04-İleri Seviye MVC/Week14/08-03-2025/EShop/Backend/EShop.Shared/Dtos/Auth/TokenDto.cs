using System;

namespace EShop.Shared.Dtos.Auth;

public class TokenDto
{
    public string? AccessToken { get; set; }
    public DateTime AccessTokenExpirationDate { get; set; }
}
