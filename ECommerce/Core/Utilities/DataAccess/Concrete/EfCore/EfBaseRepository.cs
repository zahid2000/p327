using Core.Utilities.DataAccess.Abstract;
using Core.Utilities.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace Core.Utilities.DataAccess.Concrete.EfCore;

public  class EfBaseRepository<TEntity, TContext> :IRepository<TEntity>,IAsyncRepository<TEntity>
     where TEntity : class, IEntity, new()
    where TContext:DbContext


{
    private readonly TContext _context;
public EfBaseRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();

        return await query.Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }



    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, bool tracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();

        return predicate != null
            ? await query.Where(predicate).ToListAsync(cancellationToken)
            : await query.ToListAsync(cancellationToken);
    }

    public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = GetQuery();

        return await query.AnyAsync(predicate, cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
    private DbSet<TEntity> GetQuery()
    {
        return _context.Set<TEntity>();
    }
    private static IQueryable<TEntity> AddIncludesToQuery(string[] includes, IQueryable<TEntity> query)
    {
        if (includes is not null)
        {
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
        }        
        return query;
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, bool tracking = true)
    {
        IQueryable<TEntity> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();

        return predicate != null
            ?  query.Where(predicate).ToList()
            : query.ToList();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate, string[] includes = null, bool tracking = true)
    {
        IQueryable<TEntity> query = GetQuery();
        query = AddIncludesToQuery(includes, query);
        if (!tracking) query = query.AsNoTracking();

        return  query.Where(predicate).FirstOrDefault();
    }

    public TEntity Add(TEntity entity)
    {
         _context.Set<TEntity>().Add(entity);
         _context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
        return entity;
    }
 
    public bool IsExists(Expression<Func<TEntity, bool>> predicate)
    {
        IQueryable<TEntity> query = GetQuery();

        return  query.Any(predicate);
    }
}
