using AutoFrontend.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace AutoFrontend.Themes.Monitor;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseMonitorTheme(this IServiceCollection services)
    {
        services.UseAutoFrontendForWindowsForms();
        return services;
    }
}
