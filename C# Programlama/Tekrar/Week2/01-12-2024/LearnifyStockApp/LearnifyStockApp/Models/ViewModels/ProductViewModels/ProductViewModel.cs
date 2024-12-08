using System;

namespace LearnifyStockApp.Models.ViewModels.ProductViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int StockQuantity { get; set; }
    public int MinimumStockLevel { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
    public string? CategoryName { get; set; }
    public string? SupplierName { get; set; }
}
