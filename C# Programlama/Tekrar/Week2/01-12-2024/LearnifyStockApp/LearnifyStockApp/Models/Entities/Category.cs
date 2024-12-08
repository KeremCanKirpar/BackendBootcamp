using System;

namespace LearnifyStockApp.Models.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
