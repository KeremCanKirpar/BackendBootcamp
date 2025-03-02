using System;
using System.Linq.Expressions;

namespace EShop.Data.Abstract;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(int id);
    Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes
    );
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
        bool showIsDeleted=false,
        params Func<IQueryable<TEntity>, IQueryable<TEntity>>[] includes
    );
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
