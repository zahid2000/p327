using Core.Utilities.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Core.Utilities.Extensions;

public static class ExceptionHandlerExtension
{
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        //app.UseMiddleware<GlobalExceptionHandlerMiddleware2>();
        app.UseMiddleware<GlobalExceptionHandlerMidddleware>();
    }
}
