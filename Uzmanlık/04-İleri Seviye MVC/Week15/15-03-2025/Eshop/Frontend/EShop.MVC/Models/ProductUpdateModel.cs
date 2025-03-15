using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EShop.MVC.Models;

public class ProductUpdateModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olmalıdır.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Ürün özellikleri zorunludur.")]
    [StringLength(10000, ErrorMessage = "Ürün özellikleri en fazla 10000 karakter olmalıdır.")]
    public string? Properties { get; set; }

    [Required(ErrorMessage = "Ürün fiyatı zorunludur.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır.")]
    [RegularExpression(@"^\d+([.,]\d{1,2})?$", ErrorMessage = "Ürün fiyatı geçerli bir sayı olmalıdır.")]
    public decimal? Price { get; set; }

    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = "Her ürün için en az bir kategori zorunludur.")]
    public ICollection<int> CategoryIds { get; set; } = [];

    [Required(ErrorMessage = "Anasayfa Ürünü alanı zorunludur.")]
    public bool IsHome { get; set; }

}