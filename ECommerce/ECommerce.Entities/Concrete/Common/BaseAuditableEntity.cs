namespace ECommerce.Entities.Concrete.Common;

public class BaseAuditableEntity:BaseEntity
{
    public string CreateBy { get; set; }
    public string CreateDate { get; set; }
    public string UpdateBy { get; set; }
    public string UpdateDate { get; set; }
}
