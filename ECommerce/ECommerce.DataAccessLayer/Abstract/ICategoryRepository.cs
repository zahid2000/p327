using Core.DataAccess.Abstract;

namespace ECommerce.DataAccessLayer.Abstract;

public interface ICategoryRepository:IRepository<Category>,IAsyncRepository<Category>
{
}
