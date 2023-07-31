using ECommerce.Business.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities.Concrete;

namespace ECommerce.Business.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task Add(Category category)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetById(int id)
    {
        return await _categoryRepository.GetAsync(c=>c.Id==id);
    }

    public Task<bool> IsExistsById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Category category)
    {
        throw new NotImplementedException();
    }
}
