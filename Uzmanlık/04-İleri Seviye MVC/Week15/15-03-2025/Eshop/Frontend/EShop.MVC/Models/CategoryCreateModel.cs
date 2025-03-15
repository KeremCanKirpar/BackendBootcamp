using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EShop.MVC.Models;

public class CategoryCreateModel
{
    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olmalıdır.")]
    public string? Name { get; set; }

    [Display(Name = "Kategori Açıklaması")]
    [StringLength(300, ErrorMessage = "Kategori açıklaması en fazla 300 karakter olmalıdır.")]
    public string? Description { get; set; }

    [Display(Name = "Kategori Resmi")]
    public IFormFile? Image { get; set; }

    [Display(Name = "Menüde Gösterilsin mi?")]
    public bool IsMenuItem { get; set; }
}