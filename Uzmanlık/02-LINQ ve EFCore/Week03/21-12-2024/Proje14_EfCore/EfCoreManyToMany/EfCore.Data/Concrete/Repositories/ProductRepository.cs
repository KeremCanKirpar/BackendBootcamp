using System;
using EfCore.Data.Abstract;
using EfCore.Data.Concrete.Contexts;
using EfCore.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data.Concrete.Repositories;

public class ProductRepository : GenericRepository<ProductRepository>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public Task AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllDeletedProductsAsync(bool isDeleted = true)
    {
        var products = await _appDbContext
                        .Products
                        .Where(x=>x.IsDeleted==isDeleted)
                        .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int CategoryId)
    {
       var products = await _appDbContext
                            .Products
                            .Include(x=>x.ProductCategories)
                            .ThenInclude(y=>y.Category)
                            .Where(x=>x.ProductCategories.Any(y=>y.CategoryId==CategoryId))
                            .ToListAsync();
        return products;
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Product>> IGenericRepository<Product>.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<Product> IGenericRepository<Product>.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
