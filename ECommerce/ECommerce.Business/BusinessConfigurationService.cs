using Core.Utilities.Security.JWT;
using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Business;

public static class BusinessConfigurationService
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection service)
    {
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<ICartItemService, CartItemService>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<ITokenHelper, JWTHelper>();

        return service;
    }
}
