using Core.Utilities.DataAccess.Abstract;

namespace ECommerce.DataAccessLayer.Abstract;

public interface IManufacturerRepository : IRepository<Manufacturer>, IAsyncRepository<Manufacturer>
{
}

