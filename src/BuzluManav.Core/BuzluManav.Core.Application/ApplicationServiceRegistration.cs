using System.Reflection;
using BuzluManav.Core.Application.Interfaces.Services;
using BuzluManav.Core.Application.Services.AuthService;
using BuzluManav.Core.Application.Services.CategoryService;
using BuzluManav.Core.Application.Services.RefreshTokenService;
using BuzluManav.Core.Application.Services.UserService;
using BuzluManav.Infrastructure.Infrastructure.FileService;
using CorePackages.Core.Application.Pipelines.Authorization;
using CorePackages.Core.Application.Pipelines.Caching;
using CorePackages.Core.Application.Pipelines.Logging;
using CorePackages.Core.Application.Pipelines.Transaction;
using CorePackages.Core.Application.Pipelines.Validation;
using CorePackages.Core.Application.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BuzluManav.Core.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IFileService, FileManager>();
        
        return services;
    }
    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
        )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}