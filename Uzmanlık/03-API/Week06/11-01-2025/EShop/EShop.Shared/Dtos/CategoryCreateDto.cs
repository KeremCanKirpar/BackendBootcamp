using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace EShop.Shared.Dtos;

public class CategoryCreateDto 
{
    [Required(ErrorMessage ="Kategori Adı Zorunludur!")]
    [StringLength(100, ErrorMessage = "Kategori Adı en fazla 100 karakter olmalıdır!")]
    public string? Name { get; set; }

    [StringLength(300, ErrorMessage = "Kategori Açıklaması en fazla 300 karakter olmalıdır!")]
    public string? Description { get; set; }
    public IFormFile? Image { get; set; }
}
