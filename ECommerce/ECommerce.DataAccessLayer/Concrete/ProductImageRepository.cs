using Core.Utilities.DataAccess.Concrete.EfCore;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;

namespace ECommerce.DataAccessLayer.Concrete;

public class ProductImageRepository : EfBaseRepository<ProductImage, AppDbContext>, IProductImageRepository
{
    public ProductImageRepository(AppDbContext context) : base(context)
    {
    }
}
