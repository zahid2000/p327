using Core.Utilities.Entities.Abstract;

namespace ECommerce.Entities.Dtos.Products;

public class ProductUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public double Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public int ManufacturerId { get; set; }
}
