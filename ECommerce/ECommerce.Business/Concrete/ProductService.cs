using ECommerce.Business.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities.Concrete;

namespace ECommerce.Business.Concrete;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Add(Product product)
    {
        if (product is not null)
        {
            await _productRepository.AddAsync(product);
        }
    }

    public async Task Delete(Product product)
    {

        if (product is not null)
        {
            await _productRepository.DeleteAsync(product);
        }
    }

    public async Task DeleteById(int id)
    {
        Product product =await GetById(id);
        if (product is not null)
        {
            await _productRepository.DeleteAsync(product);
        }
    }

    public async Task<List<Product>> GetAll()
    {
        return await _productRepository.GetAllAsync(includes: new string[] { "Category", "Manufacturer" });
    }

    public async Task<Product> GetById(int id)
    {
        return await _productRepository.GetAsync(p => p.Id == id,new string[]{ "Category","Manufacturer"});
    }

    public async Task<bool> IsExistsById(int id)
    {
       
        return await _productRepository.IsExistsAsync(p=>p.Id==id);
    }

    public async Task Update(Product product)
    {
        if (product is not null)
        {
            await _productRepository.UpdateAsync(product);
        }
    }
}
