namespace ECommerce.Entities.Concrete.Common;

public class BaseAuditableEntity:BaseEntity
{
    public string? CreateBy { get; set; }
    public DateTime CreateDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
}
