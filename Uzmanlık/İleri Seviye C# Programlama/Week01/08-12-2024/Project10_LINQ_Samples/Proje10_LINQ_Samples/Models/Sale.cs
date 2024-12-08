using System;

namespace Proje10_LINQ_Samples;

public class Sale
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
}
