

namespace ECommerce.DataAccessLayer.Abstract;

public interface IProductRepository:IRepository<Product>,IAsyncRepository<Product>
{
    Product CustomGetById(int id);
}

