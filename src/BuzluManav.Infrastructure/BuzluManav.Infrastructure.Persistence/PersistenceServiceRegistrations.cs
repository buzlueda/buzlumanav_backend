using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BuzluManav.Core.Application.Interfaces.Repositories.Common;
using BuzluManav.Infrastructure.Persistence.Contexts;
using BuzluManav.Infrastructure.Persistence.Repositories.Common;


namespace BuzluManav.Infrastructure.Persistence;

public static class PersistenceServiceRegistrations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BuzluManavDbContext>(options =>
        {
            var connectionString = Environment.GetEnvironmentVariable("BuzluManavDbConnection")
                                            ?? configuration.GetConnectionString("BuzluManavDbConnection");

            options.UseSqlServer(connectionString)
;
            options.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            options.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.CommandExecuting));
            options.LogTo(Console.WriteLine, LogLevel.Error)
                .EnableSensitiveDataLogging(false)
                .EnableDetailedErrors(false);
        });



        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}