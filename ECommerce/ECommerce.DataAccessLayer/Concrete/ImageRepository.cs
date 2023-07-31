using Core.Utilities.DataAccess.Concrete.EfCore;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;

namespace ECommerce.DataAccessLayer.Concrete;

public class ImageRepository : EfBaseRepository<Image, AppDbContext>, IImageRepository
{
    public ImageRepository(AppDbContext context) : base(context)
    {
    }
}