using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EShop.Shared.Dtos;

public class ProductUpdateDto
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
    public decimal? Price { get; set; }
    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = "Her ürün için en az bir kategori zorunludur.")]
    public ICollection<int> CategoryIds { get; set; } = new List<int>();
    [Required(ErrorMessage = "Aktif/Pasif durumu zorunludur.")]
    public bool IsActive { get; set; }

    [Required(ErrorMessage = "Silinme durumu zorunludur.")]
    public bool IsDeleted { get; set; }
}
