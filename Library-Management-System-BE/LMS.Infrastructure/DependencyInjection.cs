using LMS.Domain.Interfaces.Repositories;
using LMS.Infrastructure.Repos.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register all repositories via Scrutor assembly scanning
        services.Scan(scan => scan
            .FromAssemblyOf<BookRepository>()
            .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // Register Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
