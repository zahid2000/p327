using Core.DataAccess.Concrete.EfCore;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;

namespace ECommerce.DataAccessLayer.Concrete;

public class ManufacturerRepository : EfBaseRepository<Manufacturer, AppDbContext>, IManufacturerRepository
{
    public ManufacturerRepository(AppDbContext context) : base(context)
    {
    }
}