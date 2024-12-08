using System;

namespace LearnifyStockApp.Models.Entities;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Contact { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
