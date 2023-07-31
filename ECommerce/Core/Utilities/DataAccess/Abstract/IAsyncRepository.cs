using Core.Utilities.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.Utilities.DataAccess.Abstract;

public interface IAsyncRepository<T>
    where T : class,IEntity,new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}
