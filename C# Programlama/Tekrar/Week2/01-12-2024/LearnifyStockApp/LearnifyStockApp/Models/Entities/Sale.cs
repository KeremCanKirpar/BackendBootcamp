using System;

namespace LearnifyStockApp.Models.Entities;

public class Sale
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public bool IsDeleted { get; set; }
}
