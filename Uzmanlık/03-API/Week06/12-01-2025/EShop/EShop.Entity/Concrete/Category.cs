using System;
using EShop.Entity.Abstract;

namespace EShop.Entity.Concrete;

public class Category : BaseEntity
{
    private Category()//EF Core için
    {

    }
    public Category(string? name, string? imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; } = new HashSet<ProductCategory>();

}
