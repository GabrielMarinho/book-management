using System.Linq.Expressions;
using BookManager.Domain.Base;
using BookManager.Domain.Interfaces.Repositories;
using BookManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query;

namespace BookManager.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity>(BookManagerContext context) : IBaseRepository<TEntity>
    where TEntity : Entity
{
    protected readonly BookManagerContext Context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return _dbSet.CountAsync(cancellationToken);
    }

    public Task<TEntity?> GetByIdAsync(long id,
        CancellationToken cancellationToken = default)
    {
        return _dbSet
            .FirstOrDefaultAsync(f => f.Id == id,
                cancellationToken);
    }

    public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filterExpression,
        CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] properties)
    {
        var query = _dbSet.AsQueryable();
        if (properties.Length == 0)
            return _dbSet
                .FirstOrDefaultAsync(
                    filterExpression,
                    cancellationToken);

        if (properties is [_, ..])
        {
            query = properties.Aggregate(query, (current, 
                property) => current.Include(property));
        }

        return query
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await _dbSet
            .AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await Task.CompletedTask;
    }

    public async Task ExecuteUpdateAsync(Expression<Func<TEntity, bool>> filterExpression,
        Expression<Func<SetPropertyCalls<TEntity>,SetPropertyCalls<TEntity>>> properties,
        CancellationToken cancellationToken = default)
    {
        await _dbSet
            .IgnoreQueryFilters()
            .Where(filterExpression)
            .ExecuteUpdateAsync(properties,
                cancellationToken);
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> filterExpression,
        CancellationToken cancellationToken = default)
    {
        await ExecuteUpdateAsync(filterExpression,
            p => 
                p.SetProperty(p1 => p1.IsActive, false)
                    .SetProperty(p1 => p1.IsDeleted, true)
                    .SetProperty(p1 => p1.UpdatedAt, DateTime.Now),
            cancellationToken);
    }

    public async Task ExecuteDeleteAsync(
        Expression<Func<TEntity, bool>> filterExpression,
        CancellationToken cancellationToken = default)
    {
        await _dbSet
            .Where(filterExpression)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public IAsyncEnumerable<TEntity> PageAsync(int page, int pageSize)
    {
        return _dbSet
            .AsNoTracking()
            .OrderBy(o => o.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsAsyncEnumerable();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Context.SaveChangesAsync(cancellationToken);
    }
}