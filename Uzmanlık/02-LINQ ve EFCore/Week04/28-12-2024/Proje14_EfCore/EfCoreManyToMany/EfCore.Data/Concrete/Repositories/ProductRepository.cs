using System;
using EfCore.Data.Abstract;
using EfCore.Data.Concrete.Contexts;
using EfCore.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data.Concrete.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Product>> GetAllDeletedProductsAsync(bool isDeleted = true)
    {
        var products = await _appDbContext
                            .Products
                            .Where(x => x.IsDeleted == isDeleted)
                            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        var products =
            await _appDbContext
            .Products
            .Include(x => x.ProductCategories)
            .ThenInclude(y => y.Category)
            .Where(x => x.ProductCategories.Any(y => y.CategoryId == categoryId))
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<Product>> GetProductsWithCategoriesAsync()
    {
        var products =
            await _appDbContext
            .Products
            .Include(x => x.ProductCategories)
            .ThenInclude(y => y.Category)
            .ToListAsync();
        return products;
    }

    public async Task<Product> GetProductWithCategoriesAsync(int id)
    {
        var product =
            await _appDbContext
            .Products
            .Where(x => x.Id == id)
            .Include(x => x.ProductCategories)
            .ThenInclude(y => y.Category)
            .FirstOrDefaultAsync();
        return product;
    }
}
