using AutoMapper;
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

    public async Task Add(ProductCreateDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
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
        ProductGetDto productDto = await GetById(id);
        Product product = _mapper.Map<Product>(productDto);
        if (product is not null)
            await _productRepository.DeleteAsync(product);
    }

    public async Task<List<ProductGetDto>> GetAll()
    {
        var products = await _productRepository.GetAllAsync(includes: new string[] { "Category", "Manufacturer" });
        return _mapper.Map<List<ProductGetDto>>(products);
    }

    public async Task<ProductGetDto> GetById(int id)
    {
        Product product = await _productRepository.GetAsync(p=>p.Id==id,includes: new string[] { "Category", "Manufacturer" });
        return _mapper.Map<ProductGetDto>(product);
    }

    public async Task<bool> IsExistsById(int id)
    {

        return await _productRepository.IsExistsAsync(p => p.Id == id);
    }

    public async Task Update(ProductUpdateDto productdto)
    {

        Product existsProduct = await _productRepository.GetAsync(p => p.Id == productdto.Id);

        if (existsProduct is not null)
        {
            Product product = _mapper.Map(productdto,existsProduct);
            await _productRepository.UpdateAsync(product);
        }
    }
}
