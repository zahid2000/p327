using ECommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }    

}
