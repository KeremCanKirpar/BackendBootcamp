using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EShop.Shared.Dtos;

public class ProductUpdateDto
{
    
    public int Id { get; set; }
    [Required(ErrorMessage = "Ürün adı Zorunludur")]
    [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olmalıdır")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Ürün özellikleri Zorunludur")]
    [StringLength(10000, ErrorMessage = "Ürün adı en fazla 10000 karakter olmalıdır")]

    public string? Properties { get; set; }

    [Required(ErrorMessage = "Ürün fiyatı Zorunludur")]
    [Range(0, double.MaxValue, ErrorMessage = "Ürün fiyatı 0'dan büyük olmalıdır")]
    public decimal? Price { get; set; }
    public IFormFile? ImageUrl { get; set; }

    [Required(ErrorMessage = "En az bir kategori seçmelisiniz")]
    public ICollection<int> CategoryIds { get; set; } = new List<int>();
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

}
