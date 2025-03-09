using System;

namespace EShop.Shared.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
}
