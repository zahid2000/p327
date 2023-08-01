using Core.Utilities.Results.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.Products;

namespace ECommerce.Business.Abstract;

public interface IProductService
{
    Task<IDataResult<List<ProductGetDto>>> GetAll();
    Task<IDataResult<ProductGetDto>> GetById(int id);
    Task<IResult> Add(ProductCreateDto productDto);
    Task<IResult> Update(ProductUpdateDto productDto);
    Task<IResult> DeleteById(int id);
    Task<IResult> Delete(Product product);
    Task<IDataResult<bool>> IsExistsById(int id);
    Task<IDataResult<bool>> IsExistsByName(string name);
}
