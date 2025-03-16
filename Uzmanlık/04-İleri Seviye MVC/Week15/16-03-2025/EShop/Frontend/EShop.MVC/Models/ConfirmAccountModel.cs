using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class ConfirmAccountModel
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
