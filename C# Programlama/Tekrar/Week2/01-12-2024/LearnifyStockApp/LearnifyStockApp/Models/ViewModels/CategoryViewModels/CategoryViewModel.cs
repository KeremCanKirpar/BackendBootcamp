using System;
using System.ComponentModel.DataAnnotations;

namespace LearnifyStockApp.Models.ViewModels.CategoryViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Boş bırakılamaz")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Boş bırakılamaz")]
    public string? Description { get; set; }
    public DateTime UpdatedAt { get; set; }
}
