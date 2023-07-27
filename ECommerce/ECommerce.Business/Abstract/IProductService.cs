using ECommerce.Entities.Concrete;

namespace ECommerce.Business.Abstract;

public interface IProductService
{
    Task<List<Product>> GetAll();
    Task<Product> GetById(int id);
    Task Add(Product product);
    Task Update(Product product);
    Task DeleteById(int id);
    Task Delete(Product product);
    Task<bool> IsExistsById(int id);
}
