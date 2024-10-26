using System;

namespace Project07_MVCTemelleri.Models;

public class HomePageModel
{
    public List<Category>? Categories { get; set; }
    public List<Product>? Products { get; set; }
    public string? Message { get; set; }
    public Campaign? Campaign { get; set; }
}
