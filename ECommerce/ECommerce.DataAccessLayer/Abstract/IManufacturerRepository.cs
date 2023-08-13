using Core.DataAccess.Abstract;

namespace ECommerce.DataAccessLayer.Abstract;

public interface IManufacturerRepository : IRepository<Manufacturer>, IAsyncRepository<Manufacturer>
{
}

