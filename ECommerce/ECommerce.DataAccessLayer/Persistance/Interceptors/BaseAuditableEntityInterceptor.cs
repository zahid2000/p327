using ECommerce.Entities.Concrete.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerce.DataAccessLayer.Persistance.Interceptors;

public class BaseAuditableEntityInterceptor:SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public BaseAuditableEntityInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        UpdateEntity(eventData.Context);
        return base.SavedChanges(eventData, result);
    }
    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    void UpdateEntity(DbContext context)
    {
        if (context == null) return;
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State==EntityState.Added)
            {
                entry.Entity.CreateBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.CreateDate = DateTime.Now;
            }else if (entry.State == EntityState.Modified)
            {
                entry.Entity.LastModifiedBy= _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.LastModifiedDate = DateTime.Now;
            }
        }
    }
}
