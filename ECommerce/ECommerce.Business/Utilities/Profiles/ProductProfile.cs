using AutoMapper;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.Products;

namespace ECommerce.Business.Utilities.Profiles;

public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<Product, ProductGetDto>().ReverseMap();
    }
}
