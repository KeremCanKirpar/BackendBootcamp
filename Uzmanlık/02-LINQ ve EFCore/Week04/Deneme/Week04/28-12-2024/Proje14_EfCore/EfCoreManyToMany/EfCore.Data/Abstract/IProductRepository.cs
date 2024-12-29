using System;
using EfCore.Entity.Concrete;

namespace EfCore.Data.Abstract;

public interface IProductRepository : IGenericRepository<Product>
{
    // Task<IEnumerable<Product>> GetAllAsync();
    // Task<Product> GetByIdAsync(int id);
    // Task AddAsync(Product entity);
    // Task UpdateAsync(Product entity);
    // Task DeleteAsync(Product entity);

    // IGenericRepository'den Product için miras alarak, bu interface içinde yukarıdaki metot imzalarının olmasını sağladık. (TEntity yerine Product)

    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetAllDeletedProductsAsync(bool isDeleted = true);
    Task<Product> GetProductWithCategoriesAsync(int id);
    Task<IEnumerable<Product>> GetProductsWithCategoriesAsync();
    
}
