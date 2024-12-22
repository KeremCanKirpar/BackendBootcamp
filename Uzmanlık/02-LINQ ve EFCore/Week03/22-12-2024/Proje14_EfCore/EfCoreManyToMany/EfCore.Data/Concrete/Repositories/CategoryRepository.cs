using System;
using EfCore.Data.Abstract;
using EfCore.Data.Concrete.Contexts;
using EfCore.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Data.Concrete.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllDeletedCategoriesAsync(bool isDeleted = true)
    {
        var categories = await _appDbContext
                            .Categories
                            .Where(x=>x.IsDeleted==isDeleted)
                            .ToListAsync();
        return categories;
    }
}
