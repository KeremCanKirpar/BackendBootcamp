using System;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Shared.Dtos;

public class ProductUpdateDto
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Boş bırakmayınız!")]
    public string? Name { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public int[] CategoryIds { get; set; }
    public List<CategoryDto>? CategoryList { get; set; }
}
