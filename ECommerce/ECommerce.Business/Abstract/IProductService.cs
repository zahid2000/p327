using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.Products;

namespace ECommerce.Business.Abstract;

public interface IProductService
{
    Task<List<ProductGetDto>> GetAll();
    Task<ProductGetDto> GetById(int id);
    Task Add(ProductCreateDto productDto);
    Task Update(ProductUpdateDto productDto);
    Task DeleteById(int id);
    Task Delete(Product product);
    Task<bool> IsExistsById(int id);
}
