using Core.Entities.Concrete.Auth;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;
using ECommerce.DataAccessLayer.Persistance.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DataAccessLayer;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<BaseAuditableEntityInterceptor>();
        services.AddScoped<CartItemInterceptor>();
        services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.Password.RequireUppercase = false;
            opt.Lockout.MaxFailedAccessAttempts = 3;
        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        return services;    
    }
}
