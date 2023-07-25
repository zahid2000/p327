using ECommerce.Entities.Concrete.Common;
using System.Collections.ObjectModel;

namespace ECommerce.Entities.Concrete;

public class Manufacturer:BaseEntity
{
    public Manufacturer()
    {
        Products=new List<Product>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
    public List<Product> Products { get; set; }

}
