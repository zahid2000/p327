using Core.Utilities.DataAccess.Concrete.EfCore;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;

namespace ECommerce.DataAccessLayer.Concrete;

public class CategoryRepository : EfBaseRepository<Category, AppDbContext>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
