using Core.DataAccess.Concrete.EfCore;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;
using System.Linq.Expressions;

namespace ECommerce.DataAccessLayer.Concrete;

public class ProductRepository : EfBaseRepository<Product, AppDbContext>, IProductRepository
{
    private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Product CustomGetById(int id)
    {
       return _context.Products.Find(id);
    }
}
