using ECommerce.Entities.Concrete.Common;

namespace ECommerce.Entities.Concrete;

public class Category:BaseEntity
{
    public Category()
    {
        Products = new List<Product>();
    }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }

    public List<Product> Products { get; set; }
}
