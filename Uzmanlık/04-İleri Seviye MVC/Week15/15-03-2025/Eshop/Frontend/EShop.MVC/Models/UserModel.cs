using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Models
{
    public class UserModel
    {
        public string Id { get; set; } = null!;

        [Display(Name = "Ad")]
        public string? FirstName { get; set; }

        [Display(Name = "Soyad")]
        public string? LastName { get; set; }

        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }

        [Display(Name = "Telefon")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [Display(Name = "Şehir")]
        public string? City { get; set; }

        [Display(Name = "Roller")]
        public List<string> Roles { get; set; } = [];
    }
}