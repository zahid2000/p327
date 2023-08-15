using Core.Utilities.Extensions;
using Core.Utilities.Middlewares;
using Core.Utilities.Security.Encrypting;
using Core.Utilities.Security.JWT;
using ECommerce.Business;
using ECommerce.DataAccessLayer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        TokenOption tokenOption = builder.Configuration.GetSection("TokenOptions").Get<TokenOption>();

        // Add services to the container.
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddBusinessServices();
        builder.Services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true).AddFluentValidationClientsideAdapters();

        builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience=true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer=tokenOption.Issuer,
                ValidAudience=tokenOption.Audience, 
                IssuerSigningKey=SecurityKeyHelper.CreateSecurityKey(tokenOption.Securitykey)
            };
        });


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
        });


        //builder.Services.AddTransient<GlobalExceptionHandlerMiddleware2>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.Use(async(context, next) =>
        //{
        //    try
        //    {
        //        await next(context);
        //    }
        //    catch (Exception ex)
        //    {
        //        context.Response.StatusCode = 500;
        //        context.Response.ContentType = "application/json";

        //        await context.Response.WriteAsync(
        //            JsonConvert.SerializeObject(

        //                new
        //                {
        //                    statusCode = (int)HttpStatusCode.InternalServerError,
        //                    message=ex.Message
        //                }
        //            ));
        //    }
        //});
        //app.UseMiddleware<GlobalExceptionHandlerMidddleware>();
        //app.UseMiddleware<GlobalExceptionHandlerMiddleware2>();
        app.UseGlobalExceptionHandler();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}