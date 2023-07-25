using Core.Utilities.Entities.Abstract;
using ECommerce.Entities.Concrete.Common;

namespace ECommerce.Entities.Concrete;

public class Product:BaseAuditableEntity,IEntity
{
    public string Name { get; set; } =default!;
    public double  Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public int ManufacturerId { get; set; }

}
