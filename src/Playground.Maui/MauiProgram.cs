using AutoFrontend.Builders;
using AutoFrontend.Maui;
using Playground.Services;

namespace Playground.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var demoService = new DemoService();
        var calculatorService = new CalculatorService();

        var frontendBuilder = new FrontendBuilder();
        frontendBuilder.Service(demoService);
        frontendBuilder.Service(calculatorService);
        return frontendBuilder.BuildMauiApplciation().Build();
    }
}
