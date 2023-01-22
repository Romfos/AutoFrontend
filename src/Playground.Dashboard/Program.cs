using AutoFrontend.Builders;
using AutoFrontend.WindowsForms;
using Playground.Services;
using System;

namespace Playground.Dashboard;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        var demoStateService = new UserService();

        var applicationBuilder = new ApplicationBuilder();
        applicationBuilder.Service(demoStateService);
        applicationBuilder.RunWindowsFormsApplication();
    }
}