using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Business;

public static class BusinessConfigurationService
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection service)
    {
        service.AddScoped<IProductService, ProductService>();

        return service;
    }
}
