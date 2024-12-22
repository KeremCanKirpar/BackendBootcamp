using System;
using EfCore.Entity.Concrete;

namespace EfCore.Data.Abstract;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductByCategoryAsync(int CategoryId);
    Task<IEnumerable<Product>> GetAllDeletedProductsAsync(bool isDeleted=true);
}
