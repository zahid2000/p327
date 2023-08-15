using Core.Utilities.Results.Abstract;
using ECommerce.Entities.Dtos.CartItems;

namespace ECommerce.Business.Abstract;

public interface ICartItemService
{
    Task<IDataResult<List<CartItemDetailDto>>> GetAllAsync();
    Task<IDataResult<CartItemDetailDto>> GetByIdAsync(int id);
    Task<IResult> AddAsync(CartItemCreateDto dto);
    Task<IResult> UpdateAsync(CartItemUpdateDto dto);
    Task<IResult> DeleteByIdAsync(int id);

}
