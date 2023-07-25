using Core.Utilities.Entities.Abstract;
using ECommerce.Entities.Concrete;

namespace ECommerce.Entities.Dtos.Categories;

public class CategoryGetDto : IDto
{
    public CategoryGetDto()
    {
        Products = new List<Product>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}