using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EShop.MVC.Models;

public class CategoryUpdateModel
{
    public int Id { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olmalıdır.")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Kategori Açıklaması")]
    [StringLength(300, ErrorMessage = "Kategori açıklaması en fazla 300 karakter olmalıdır.")]
    public string? Description { get; set; }

    [Display(Name = "Kategori Resmi")]
    public IFormFile? Image { get; set; }

    [Display(Name = "Aktif Mi?")]
    public bool IsActive { get; set; }

    [Display(Name = "Menüde Gösterilsin Mi?")]
    public bool IsMenuItem { get; set; }
}