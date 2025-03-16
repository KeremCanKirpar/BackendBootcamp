namespace EShop.Shared.Dtos.UserDtos;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public List<string> Roles { get; set; } = new();
}