using System.Linq.Expressions;
using BookManager.Domain.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace BookManager.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity: Entity
{
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filterExpression,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] properties);
    
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity);

    Task ExecuteUpdateAsync(Expression<Func<TEntity, bool>> filterExpression,
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> properties,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(Expression<Func<TEntity, bool>> filterExpression,
        CancellationToken cancellationToken = default);
    
    Task ExecuteDeleteAsync(Expression<Func<TEntity, bool>> filterExpression,
        CancellationToken cancellationToken = default);

    IAsyncEnumerable<TEntity> PageAsync(int page, int pageSize);
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

}