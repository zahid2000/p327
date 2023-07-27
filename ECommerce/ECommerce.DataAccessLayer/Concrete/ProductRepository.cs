using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;
using System.Linq.Expressions;

namespace ECommerce.DataAccessLayer.Concrete;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken = default)
    {
         _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> GetAsync(Expression<Func<Product, bool>> predicate, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<Product> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();

        return await query.Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }



    public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate = null, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<Product> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();

        return predicate != null
            ?await query.Where(predicate).ToListAsync(cancellationToken)
            :await query.ToListAsync(cancellationToken);
    }

    public async Task<bool> IsExistsAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        IQueryable<Product> query = GetQuery();

        return  await query.AnyAsync(predicate, cancellationToken);
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }
    private DbSet<Product> GetQuery()
    {
        return _context.Set<Product>();
    }
    private static IQueryable<Product> AddIncludesToQuery(string[] includes, IQueryable<Product> query)
    {
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }
}
