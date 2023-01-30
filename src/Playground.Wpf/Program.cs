using AutoFrontend.Builders;
using AutoFrontend.Wpf;
using Playground.Services;
using System;

internal class Program
{
    [STAThread]
    public static void Main()
    {
        var demoStateService = new UserService();
        var calculatorService = new CalculatorService();

        var applicationBuilder = new FrontendBuilder();
        applicationBuilder.Service(demoStateService);
        applicationBuilder.Service(calculatorService);
        var wpfFrontendBuilder = applicationBuilder.BuildWpfFrontend();
        wpfFrontendBuilder.RunWpfApplication();
    }
}