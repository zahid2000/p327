using Core.Utilities.DataAccess.Concrete.EfCore;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;
using System.Linq.Expressions;

namespace ECommerce.DataAccessLayer.Concrete;

public class ProductRepository : EfBaseRepository<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
