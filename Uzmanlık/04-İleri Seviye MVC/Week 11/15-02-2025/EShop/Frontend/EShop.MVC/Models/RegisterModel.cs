using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
            int year = DateTime.Now.Year - 18;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            DateOfBirth = new DateTime(year, month, day);
        }
        [Display(Name ="Ad")]
        [Required(ErrorMessage ="{0} alanı zorunludur!")]
        [JsonPropertyName("firstName")]
        public string? firstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; } 


        [JsonPropertyName("address")]
        public string? Address { get; set; } 

        [JsonPropertyName("city")]
        public string? City { get; set; } 

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
       
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir {0}  adresi giriniz!")]
        [JsonPropertyName("email")]
        public string? email { get; set; }
       
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} alanı zorunludur!")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string? Password { get; set; } 

        [JsonPropertyName("confirmPassword")]
        public string? ConfirmPassword { get; set; } 
        
        [Display(Name = "Rol")]
        [JsonPropertyName("role")]
        public string? Role {get; set;}
    }

    public enum Gender
    {
        None = 1,
        Female = 2,
        Male = 3
    }
}
