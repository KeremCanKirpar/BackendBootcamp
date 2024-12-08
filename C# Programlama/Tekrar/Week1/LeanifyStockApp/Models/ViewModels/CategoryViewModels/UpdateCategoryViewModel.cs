using System;

namespace Tekrar.Models.ViewModels.CategoryViewModels;

public class UpdateCategoryViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
}

