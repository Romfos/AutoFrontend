using AutoFrontend.Builders;

namespace AutoFrontend.Wpf;

public static class FrontendBuilderExtensions
{
    public static WpfFrontendBuilder BuildWpfFrontend(this FrontendBuilder frontendBuilder)
    {
        var frontend = frontendBuilder.ToFrontend();
        return new WpfFrontendBuilder(frontend);
    }
}
