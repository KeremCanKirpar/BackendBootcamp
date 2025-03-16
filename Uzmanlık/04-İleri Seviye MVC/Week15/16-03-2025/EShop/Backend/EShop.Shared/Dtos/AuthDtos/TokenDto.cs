namespace EShop.Shared.Dtos.AuthDtos
{
    public class TokenDto
    {
        public string? AccessToken { get; set; }
        public DateTime AccessTokenExpirationDate { get; set; }
    }
}
