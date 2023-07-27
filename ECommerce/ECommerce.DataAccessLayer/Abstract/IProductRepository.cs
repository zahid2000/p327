using System.Linq.Expressions;

namespace ECommerce.DataAccessLayer.Abstract;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(Expression<Func<Product,bool>> predicate=null,string[] includes=null,bool tracking =true,CancellationToken cancellationToken=default);
    Task<Product> GetAsync(Expression<Func<Product, bool>> predicate, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default);

    Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken = default);
    Task<bool> IsExistsAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default);

}
