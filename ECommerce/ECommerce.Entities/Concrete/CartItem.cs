using Core.Entities.Concrete.Auth;
using ECommerce.Entities.Concrete.Common;

namespace ECommerce.Entities.Concrete;

public class CartItem:BaseAuditableEntity
{
    public int Count { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser{ get; set; }
}
