using Core.Utilities.Entities.Abstract;
using ECommerce.Entities.Concrete.Common;

namespace ECommerce.Entities.Concrete;

public class Product:BaseAuditableEntity
{
    public Product()
    {
        ProductImages = new List<ProductImage>();
    }
    public string Name { get; set; } =default!;
    public double  Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public List<ProductImage> ProductImages{ get; set; }
    

}
