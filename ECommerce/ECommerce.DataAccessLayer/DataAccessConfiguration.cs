using ECommerce.DataAccessLayer.Persistance.Context.EfCore;
using ECommerce.DataAccessLayer.Persistance.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DataAccessLayer;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddScoped<BaseAuditableEntityInterceptor>();
        return services;    
    }
}
