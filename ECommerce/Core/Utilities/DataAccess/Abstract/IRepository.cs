using Core.Utilities.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.Utilities.DataAccess.Abstract;

public interface IRepository<T>
    where T : class, IEntity, new()
{
    List<T> GetAll(Expression<Func<T, bool>> predicate = null, string[] includes = null, bool tracking = true);
    T Get(Expression<Func<T, bool>> predicate, string[] includes = null, bool tracking = true);

    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
    bool IsExists(Expression<Func<T, bool>> predicate);
}
