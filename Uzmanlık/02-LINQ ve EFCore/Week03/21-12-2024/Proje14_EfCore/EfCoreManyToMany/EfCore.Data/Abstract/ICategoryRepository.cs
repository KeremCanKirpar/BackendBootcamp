using System;
using EfCore.Entity.Concrete;

namespace EfCore.Data.Abstract;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<IEnumerable<Category>> GetAllDeletedCategoriesAsync(bool isDeleted = true);
}
