using Core.Entities.Concrete.Auth;
using ECommerce.Entities.Concrete;

namespace ECommerce.Entities.Dtos.CartItems;

public class CartItemCreateDto
{
    public int Count { get; set; }
    public int ProductId { get; set; }
}
