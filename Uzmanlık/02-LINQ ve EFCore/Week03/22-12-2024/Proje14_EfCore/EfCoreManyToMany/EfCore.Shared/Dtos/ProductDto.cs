using System;

namespace EfCore.Shared.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public List<CategoryDto> Categories { get; set; }
}
