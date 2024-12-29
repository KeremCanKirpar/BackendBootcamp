using System;
using EfCore.Entity.Abstract;

namespace EfCore.Entity.Concrete;

public class Category:BaseEntity
{
    public string? Description { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
}
