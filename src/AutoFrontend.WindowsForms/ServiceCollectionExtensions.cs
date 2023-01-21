using Microsoft.Extensions.DependencyInjection;

namespace AutoFrontend.WindowsForms;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseAutoFrontendForWindowsForms(this IServiceCollection services)
    {
        services.UseAutoFrontend();
        return services;
    }
}
