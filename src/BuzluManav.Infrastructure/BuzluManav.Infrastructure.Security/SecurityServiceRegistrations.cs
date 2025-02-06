using BuzluManav.Core.Application.Interfaces.Helpers;
using BuzluManav.Infrastructure.Security.JWT;
using CorePackages.Infrastructure.Security.DependencyInjections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuzluManav.Infrastructure.Security;

public static class SecurityServiceRegistrations
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();

        JWTAuthenticationScheme.AddJWTBearerAuthentication(services, signalRHubEndpoint: "/", configuration);

        return services;
    }
}