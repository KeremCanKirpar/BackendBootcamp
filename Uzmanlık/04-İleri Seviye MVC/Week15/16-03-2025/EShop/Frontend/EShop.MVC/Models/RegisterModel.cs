using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
            int year = DateTime.Now.Year-18;
            int month= DateTime.Now.Month;
            int day = DateTime.Now.Day;
            DateOfBirth = new DateTime(year,month,day);
        }

        [Display(Name ="Ad")]
        [Required(ErrorMessage ="{0} alanı zorunludur!")]
        [MinLength(5, ErrorMessage ="{0} alanı en az {1} karakter uzunluğunda olmalıdır!")]
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [EmailAddress(ErrorMessage ="Geçersiz {0} formatı!")]
        [JsonPropertyName("email")] 
        public string? Email { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string? Password { get; set; } 

        [JsonPropertyName("confirmPassword")]
        public string? ConfirmPassword { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; } 

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }
    }

    public enum Gender
    {
        None = 1,
        Female = 2,
        Male = 3
    }
}
