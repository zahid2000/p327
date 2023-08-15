using AutoMapper;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.CartItems;

namespace ECommerce.Business.Utilities.Profiles;

public class CartItemProfiles:Profile
{
    public CartItemProfiles()
    {
        CreateMap<CartItemCreateDto,CartItem>();
        CreateMap<CartItemUpdateDto,CartItem>();
        CreateMap<CartItem,CartItemDetailDto>()
            .ForMember(c=>c.ProductName,opt=>opt.MapFrom(c=>c.Product.Name))
            .ForMember(c=>c.Price,opt=>opt.MapFrom(c=>c.Product.Price))
            ;
        
    }
}
