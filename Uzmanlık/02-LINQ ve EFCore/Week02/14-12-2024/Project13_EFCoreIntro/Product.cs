using System;

namespace Project13_EFCoreIntro;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Properties { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
