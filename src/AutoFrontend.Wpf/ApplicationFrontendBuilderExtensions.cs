using AutoFrontend.Builders;

namespace AutoFrontend.Wpf;

public static class ApplicationFrontendBuilderExtensions
{
    public static WpfFrontendBuilder BuildWpfFrontend(this ApplicationFrontendBuilder applicationFrontendBuilder)
    {
        var applicationFrontend = applicationFrontendBuilder.ToApplicationFrontend();
        return new WpfFrontendBuilder(applicationFrontend);
    }
}
