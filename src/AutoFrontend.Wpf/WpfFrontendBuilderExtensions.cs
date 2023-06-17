using AutoFrontend.Builders;

namespace AutoFrontend.Wpf;

public static class WpfFrontendBuilderExtensions
{
    public static WpfApplicationBuilder BuildWpfApplication(this FrontendBuilder frontendBuilder)
    {
        return new WpfApplicationBuilder(frontendBuilder.ToFrontendModel());
    }
}
