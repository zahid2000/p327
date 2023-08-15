using AutoMapper;
using Core.Utilities.Exceptions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ECommerce.Business.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.Products;

namespace ECommerce.Business.Concrete;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Add(ProductCreateDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        if (product is  null)
        {
            return new ErrorResult("Not Added");
                
        }
        await _productRepository.AddAsync(product);

        return new SuccessResult("Added");
    }

    public async Task<IResult> Delete(Product product)
    {

        if (product is  null)
        {
            return new ErrorResult("Not Added");
        }
        await _productRepository.DeleteAsync(product);
        return new SuccessResult("Deleted");
    }

    public async Task<IResult> DeleteById(int id)
    {
        //ProductGetDto productDto = await GetById(id).da;
        //Product product = _mapper.Map<Product>(productDto);
        //if (product is not null)
        //    await _productRepository.DeleteAsync(product);
        return null;
    }

    public async Task<IDataResult<List<ProductGetDto>>> GetAll()
    {
        var products = await _productRepository.GetAllAsync(includes: new string[] { "Category", "Manufacturer" });
        if (products.Count == 0)
            throw new NotFoundException("Product list is empty");
        return new SuccessDataResult<List<ProductGetDto>>(_mapper.Map<List<ProductGetDto>>(products),"Products Listed");
    }

    public async Task<IDataResult<ProductGetDto>> GetById(int id)
    {
        Product product = await _productRepository.GetAsync(p=>p.Id==id,includes: new string[] { "Category", "Manufacturer" });
        return new SuccessDataResult<ProductGetDto>(_mapper.Map<ProductGetDto>(product));
    }

    public async Task<IDataResult<bool>> IsExistsById(int id)
    {

        return new SuccessDataResult<bool>(await _productRepository.IsExistsAsync(p => p.Id == id));
    }

    public async Task<IDataResult<bool>> IsExistsByName(string name)
    {
        return new SuccessDataResult<bool> (await _productRepository.IsExistsAsync(p => p.Name == name));
    }

    public async Task<IResult> Update(ProductUpdateDto productdto)
    {   

        Product existsProduct = await _productRepository.GetAsync(p => p.Id == productdto.Id);

        if (existsProduct is not null)
        {
            Product product = _mapper.Map(productdto,existsProduct);
            await _productRepository.UpdateAsync(product);
        }
        return new SuccessResult("Updated");
    }
}
