using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EShop.MVC.Areas.Admin.Models;

public class ProductCreateModel
{
    [DisplayName("Ürün")]
    [Required(ErrorMessage = "Ürün adı zorunldurur!")]
    [StringLength(100, ErrorMessage = "Ürün adı 100 karakterden uzun olamaz!")]
    public string? Name { get; set; }

    [DisplayName("Ürün Açıklaması")]
    [Required(ErrorMessage = "Ürün açıklaması zorunldurur!")]
    public string Properties { get; set; } = null!;

    [DisplayName("Fiyat")]
    [Required(ErrorMessage = "Fiyat zorunldurur!")]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır!")]
    [RegularExpression(@"^\d+(\.\d\d{1,2})?")]
    public decimal? Price { get; set; }

    [DisplayName("Ürün Görseli")]
    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = "En az bir kategori seçilmelidir!")]
    public ICollection<int> CategoryIds { get; set; } = new List<int>();



}
