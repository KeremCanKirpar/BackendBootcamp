using System;

namespace LearnifyStockApp.Models.Entities;

public class StockTransaction
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TransactionTypeId { get; set; }
    public DateTime TransactionDate { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public bool IsDeleted { get; set; }
}
