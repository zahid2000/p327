using Core.Utilities.DataAccess.Abstract;

namespace ECommerce.DataAccessLayer.Abstract;

public interface IImageRepository : IRepository<Image>, IAsyncRepository<Image>
{
}

