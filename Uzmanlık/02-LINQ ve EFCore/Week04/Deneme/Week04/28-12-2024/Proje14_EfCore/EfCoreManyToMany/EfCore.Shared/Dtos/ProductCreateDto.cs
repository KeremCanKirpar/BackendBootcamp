using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCore.Shared.Dtos;

public class ProductCreateDto
{
    public string Name { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public int[] CategoryIds { get; set; } = [];
    public List<CategoryDto>? CategoryList { get; set; }
}
