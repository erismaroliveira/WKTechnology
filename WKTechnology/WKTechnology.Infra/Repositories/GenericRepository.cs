using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WKTechnology.Infra.Context;
using WKTechnology.Infra.Repositories.Interfaces;

namespace WKTechnology.Infra.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly WKTehnologyContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(WKTehnologyContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
        return entity;
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}