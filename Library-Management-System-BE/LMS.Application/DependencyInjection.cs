using LMS.Application.Managers.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register all Application services via Scrutor assembly scanning
        services.Scan(scan => scan
            .FromAssemblyOf<BookService>()
            .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
