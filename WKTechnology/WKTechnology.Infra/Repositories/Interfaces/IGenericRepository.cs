using System.Linq.Expressions;

namespace WKTechnology.Infra.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> SaveAsync();
}