using System;
using EfCore.Entity.Concrete;

namespace EfCore.Data.Abstract;
//Buradaki TEntity, Category ya da Product gibi entitylerimizden biri olabilir.
public interface IGenericRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}


