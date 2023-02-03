using System;
using AutoFrontend.Builders;
using Microsoft.Maui;

namespace AutoFrontend.Maui;

public static class FrontendBuilderExtensions
{
    public static MauiAppBuilder BuildMauiApplciation(this FrontendBuilder frontendBuilder)
    {
        return MauiApp
            .CreateBuilder()
            .UseMauiApp<App>();
    }
}

