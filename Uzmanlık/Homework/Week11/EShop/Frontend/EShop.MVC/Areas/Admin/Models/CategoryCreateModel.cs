using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Areas.Admin.Models
{
    public class CategoryCreateModel
    {
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olmalıdır.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Kategori Açıklaması")]
        [StringLength(300, ErrorMessage = "Kategori açıklaması en fazla 300 karakter olmalıdır.")]
        public string? Description { get; set; }

        [Display(Name = "Kategori Görseli")]
        [Required(ErrorMessage = "Kategori görseli zorunludur.")]
        public IFormFile? Image { get; set; }
    }
}
