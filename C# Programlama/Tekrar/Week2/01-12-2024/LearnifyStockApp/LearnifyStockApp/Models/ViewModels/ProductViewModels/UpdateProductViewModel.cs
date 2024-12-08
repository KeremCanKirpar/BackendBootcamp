using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnifyStockApp.Models.ViewModels.ProductViewModels;

public class UpdateProductViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public List<SelectListItem>? CategoryList { get; set; }
    public int SupplierId { get; set; }
    public List<SelectListItem>? SupplierList { get; set; }
    public int StockQuantity { get; set; }
    public int MinimumStockLevel { get; set; }
    public decimal Price { get; set; }
}
