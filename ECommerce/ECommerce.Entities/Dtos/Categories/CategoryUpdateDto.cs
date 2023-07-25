using Core.Utilities.Entities.Abstract;

namespace ECommerce.Entities.Dtos.Categories;

public class CategoryUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
