using System;

namespace Proje10_LINQ_Samples;

public class Supplier
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { get; set; }
    public string? ContactName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}
