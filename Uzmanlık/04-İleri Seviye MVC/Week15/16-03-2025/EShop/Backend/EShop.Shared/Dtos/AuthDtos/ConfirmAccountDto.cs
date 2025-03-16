using System;

namespace EShop.Shared.Dtos.AuthDtos
{
    public class ConfirmAccountDto
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
    }
}
