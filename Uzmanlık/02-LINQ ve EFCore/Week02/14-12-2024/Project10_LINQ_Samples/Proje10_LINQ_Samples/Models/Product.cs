using System;

namespace Proje10_LINQ_Samples;

public class Product
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public int StockQuantity { get; set; }
    public int MinimumStockLevel { get; set; }
    public decimal Price { get; set; }
}
