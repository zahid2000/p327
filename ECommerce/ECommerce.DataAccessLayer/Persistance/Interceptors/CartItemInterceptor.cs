using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Claims;

namespace ECommerce.DataAccessLayer.Persistance.Interceptors;

public class CartItemInterceptor:SaveChangesInterceptor
{
    private readonly IHttpContextAccessor  _contextAccessor;

    public CartItemInterceptor(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateCartItem(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateCartItem(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateCartItem(DbContext context)
    {
        if (context is null) return ;
        foreach (var entry in context.ChangeTracker.Entries<CartItem>())
        {
            entry.Entity.AppUserId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
