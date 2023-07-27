using ECommerce.DataAccessLayer.Persistance.Interceptors;
using ECommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext:DbContext
{
    private readonly BaseAuditableEntityInterceptor _baseAuditableEntityInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> opt, BaseAuditableEntityInterceptor baseAuditableEntityInterceptor) : base(opt)
    {
        _baseAuditableEntityInterceptor = baseAuditableEntityInterceptor;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_baseAuditableEntityInterceptor);
        optionsBuilder.UseSqlServer(@"Server=.;Database=P327ECommerce;Trusted_Connection=true;");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }    

}
