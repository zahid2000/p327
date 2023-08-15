namespace ECommerce.Entities.Dtos.CartItems;

public class CartItemUpdateDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
}
