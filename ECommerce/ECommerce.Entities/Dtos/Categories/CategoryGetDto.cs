using Core.Utilities.Entities.Abstract;
using ECommerce.Entities.Concrete;

namespace ECommerce.Entities.Dtos.Categories;

public class CategoryGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}