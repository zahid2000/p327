using Core.DataAccess.Concrete.EfCore;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;

namespace ECommerce.DataAccessLayer.Concrete;

public class CartItemRepository : EfBaseRepository<CartItem, AppDbContext>, ICartItemRepository
{
    public CartItemRepository(AppDbContext context) : base(context)
    {
    }
}
