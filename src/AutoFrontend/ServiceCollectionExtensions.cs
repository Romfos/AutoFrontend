using Microsoft.Extensions.DependencyInjection;

namespace AutoFrontend;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseAutoFrontend(this IServiceCollection services)
    {
        return services;
    }
}
