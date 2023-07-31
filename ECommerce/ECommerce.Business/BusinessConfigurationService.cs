using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Business;

public static class BusinessConfigurationService
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        return service;
    }
}
