using System;

namespace EShop.Entity.Concrete;

public class ProductCategory
{
    private ProductCategory()
    {

    }
    public ProductCategory(int productId, int categoryId)
    {
        ProductId = productId;
        CategoryId = categoryId;
    }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
