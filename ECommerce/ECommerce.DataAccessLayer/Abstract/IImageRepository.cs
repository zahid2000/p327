using Core.DataAccess.Abstract;

namespace ECommerce.DataAccessLayer.Abstract;

public interface IImageRepository : IRepository<Image>, IAsyncRepository<Image>
{
}

