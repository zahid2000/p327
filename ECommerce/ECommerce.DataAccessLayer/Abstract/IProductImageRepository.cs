using Core.DataAccess.Abstract;

namespace ECommerce.DataAccessLayer.Abstract;

public interface IProductImageRepository : IRepository<ProductImage>, IAsyncRepository<ProductImage>
{
}

