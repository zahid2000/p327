using Core.Entities.Concrete.Auth;
using ECommerce.DataAccessLayer.Persistance.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.DataAccessLayer.Persistance.Context.EfCore;

public class AppDbContext:IdentityDbContext<AppUser>
{
    private readonly BaseAuditableEntityInterceptor _baseAuditableEntityInterceptor;
    private readonly CartItemInterceptor _cartItemInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> opt, BaseAuditableEntityInterceptor baseAuditableEntityInterceptor, CartItemInterceptor cartItemInterceptor) : base(opt)
    {
        _baseAuditableEntityInterceptor = baseAuditableEntityInterceptor;
        _cartItemInterceptor = cartItemInterceptor;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_baseAuditableEntityInterceptor,_cartItemInterceptor);
        optionsBuilder.UseSqlServer(@"Server=.;Database=P327ECommerce;Trusted_Connection=true;");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

}
