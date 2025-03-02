using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "Ürün Adı Zorunludur")]
        [StringLength(maximumLength: 100, MinimumLength = 0)]
        public string? Name { get; set; }
        [DisplayName("Ürün Özellikleri")]
        [Required(ErrorMessage = "Ürün Özellikleri Zorunludur")]
        public string? Properties { get; set; }
        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "Ürün Fiyatı Zorunludur")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır")]
        [RegularExpression(@"^\d+(\.\d\d{1,2})?")]
        public decimal? Price { get; set; }
        [DisplayName("Ürün Görseli")]
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage ="En az 1 kategori seçilmelidir!")]
        public ICollection<int> CategoryIds { get; set; } = [];

    }
}
