using BuzluManav.Core.Application;
using BuzluManav.Infrastructure.Persistence;
using BuzluManav.Presentation.WebAPI.Infrastructure.Constants;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace BuzluManav.Presentation.WebAPI.Infrastructure.Extensions;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddHttpContextAccessor();
        services.AddServiceRegistrations(configuration);
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddCorsConfiguration();
        //services.AddMailConfiguration(configuration);
        services.AddFormOptionsConfiguration(configuration);
        services.AddKestrelConfiguration(configuration);
        return services;
    }

    private static IServiceCollection AddServiceRegistrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices();
        services.AddPersistenceServices(configuration);
        // services.AddSecurityServices(configuration);
        return services;
    }
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            });
        });

        return services;
    }

    public static IServiceCollection AddFormOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FormOptions>(options =>
        {
            options.ValueLengthLimit = configuration.GetValue("FormOptions:ValueLengthLimit", int.MaxValue);
            options.MultipartBodyLengthLimit = configuration.GetValue("FormOptions:MultipartBodyLengthLimit", int.MaxValue);
            options.MultipartHeadersLengthLimit = configuration.GetValue("FormOptions:MultipartHeadersLengthLimit", int.MaxValue);
        });

        return services;
    }

    public static IServiceCollection AddKestrelConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KestrelServerOptions>(options =>
        {
            options.Limits.MaxRequestBodySize = configuration.GetValue("Kestrel:Limits:MaxRequestBodySize", int.MaxValue);
        });

        return services;
    }

    public static void ConfigureSwagger(this IApplicationBuilder app)
    {
        var environment = app.ApplicationServices.GetRequiredService<IHostEnvironment>();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(WebAPIConstants.SwaggerEndpoint, WebAPIConstants.SwaggerEndpointName);
            c.RoutePrefix = WebAPIConstants.RoutePrefix;
        });
    }

    public static void ConfigureCors(this IApplicationBuilder app, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("WebAPIConfiguration")?.Get<WebAPIConfiguration>()?.AllowedOrigins ?? new[] { "http://localhost:3000" };

        app.UseCors(builder =>
        {
            builder.WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
        });
    }

    // public static IServiceCollection AddMailConfiguration(this IServiceCollection services, IConfiguration configuration)
    // {
    //     services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
    //     return services;
    // }
}