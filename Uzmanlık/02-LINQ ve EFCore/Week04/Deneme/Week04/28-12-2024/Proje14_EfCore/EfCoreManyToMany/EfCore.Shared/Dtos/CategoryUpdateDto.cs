using System;

namespace EfCore.Shared.Dtos;

public class CategoryUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
    public string? Description { get; set; }
}
