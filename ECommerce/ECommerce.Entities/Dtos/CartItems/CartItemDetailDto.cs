namespace ECommerce.Entities.Dtos.CartItems;

public class CartItemDetailDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
    public int AppUserId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public bool IsDeleted { get; set; }
}
