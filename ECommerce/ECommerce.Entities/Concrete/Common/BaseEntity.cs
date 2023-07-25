using Core.Utilities.Entities.Abstract;

namespace ECommerce.Entities.Concrete.Common;

public class BaseEntity: IEntity
{
    public int Id { get; set; }
}
