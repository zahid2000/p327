using ECommerce.Entities.Concrete;

namespace ECommerce.Business.Abstract;

public interface ICategoryService
{
    Task<List<Category>> GetAll();
    Task<Category> GetById(int id);
    Task Add(Category category);
    Task Update(Category category);
    Task DeleteById(int id);
    Task Delete(Category category);
    Task<bool> IsExistsById(int id);
}
