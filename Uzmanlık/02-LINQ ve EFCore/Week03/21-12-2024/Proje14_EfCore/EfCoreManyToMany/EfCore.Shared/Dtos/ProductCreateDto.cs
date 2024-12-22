using System;

namespace EfCore.Shared.Dtos;

public class ProductCreateDto
{
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public int[] CategoryIds { get; set; }
}
