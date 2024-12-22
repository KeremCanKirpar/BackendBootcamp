using System;

namespace EfCore.Shared.Dtos;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public int[] CategoryIds { get; set; }
}
