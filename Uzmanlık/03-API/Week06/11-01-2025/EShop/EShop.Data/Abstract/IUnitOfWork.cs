using System;

namespace EShop.Data.Abstract;

public interface IUnitOfWork: IDisposable
{
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    int save();
    Task<int> saveAsync();
}
