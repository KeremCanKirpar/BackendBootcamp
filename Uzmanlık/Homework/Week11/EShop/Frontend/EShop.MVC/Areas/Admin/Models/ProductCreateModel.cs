using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        [Display(Name= "Ürün Adı:")]
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olmalıdır.")]
        public string? Name { get; set; }

        [Display(Name = "Ürün Özellikleri:")]
        [Required(ErrorMessage = "Ürün özellikleri zorunludur.")]
        [StringLength(10000, ErrorMessage = "Ürün özellikleri en fazla 10000 karakter olmalıdır.")]
        public string? Properties { get; set; }

        [Display(Name = "Ürün Fiyatı:")]
        [Required(ErrorMessage = "Ürün fiyatı zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır.")]
        public decimal? Price { get; set; }

        [Display(Name= "Ürün Resmi:")]
        [Required(ErrorMessage = "Ürün resmi zorunludur.")]
        public IFormFile? Image { get; set; }

        [Display(Name = "Ürün Kategorisi:")]
        [Required(ErrorMessage = "Her ürün için en az bir kategori zorunludur.")]
        public ICollection<int> CategoryIds { get; set; } = new List<int>();
    }
}
