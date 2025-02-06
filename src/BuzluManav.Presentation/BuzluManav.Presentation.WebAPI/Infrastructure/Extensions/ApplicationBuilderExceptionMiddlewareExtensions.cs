using CorePackages.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Middleware;

namespace BuzluManav.Presentation.WebAPI.Infrastructure.Extensions;

public static class ApplicationBuilderExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}