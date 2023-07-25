using ECommerce.Entities.Concrete.Common;

namespace ECommerce.Entities.Concrete;

public class ProductImage:BaseAuditableEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
    public bool IsMain { get; set; }
}
