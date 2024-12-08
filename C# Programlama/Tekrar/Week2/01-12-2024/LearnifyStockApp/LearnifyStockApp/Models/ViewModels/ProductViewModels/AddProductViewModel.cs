using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnifyStockApp.Models.ViewModels.ProductViewModels;

public class AddProductViewModel
{
    [Display(Name = "Ürün")]
    [Required(ErrorMessage ="Bu alan boş Bırakılmamalıdır")]
    public string? Name { get; set; }
    [Display(Name = "Açıklama")]
    [Required(ErrorMessage = "Bu alan boş Bırakılmamalıdır")]
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public List<SelectListItem>? CategoryList { get; set; }
    public int SupplierId { get; set; }
    [Display(Name = "Tedarikçi")]
    public List<SelectListItem>? SupplierList { get; set; }
    [Display(Name = "Stok Adedi")]
    public int StockQuantity { get; set; }
    [Display(Name = "Stok Seviyesi")]
    public int MinimumStockLevel { get; set; }
    [Display(Name = "Fiyat")]
    public decimal Price { get; set; }
}
