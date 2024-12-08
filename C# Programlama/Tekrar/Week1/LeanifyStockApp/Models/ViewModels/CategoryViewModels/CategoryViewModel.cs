using System;
using System.ComponentModel.DataAnnotations;

namespace Tekrar.Models.ViewModels.CategoryViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Boş Bırakılamaz")]
    public string? Name { get; set; }
    public DateTime UpdatedAt { get; set; }
}
