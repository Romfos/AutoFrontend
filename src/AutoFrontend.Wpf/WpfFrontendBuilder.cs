using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using AutoFrontend.Wpf.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using TestFixture;

namespace AutoFrontend.Wpf;

public sealed class WpfFrontendBuilder
{
    private readonly Frontend frontend;

    private readonly ControlFactory controlFactory;
    private readonly GlobalFunctionService globalFunctionService;

    private string title = "AutoFrontend";
    private ImageSource? icon;

    public WpfFrontendBuilder(Frontend frontend)
    {
        this.frontend = frontend;

        var fixture = new Fixture();
        controlFactory = new ControlFactory(fixture);
        globalFunctionService = new GlobalFunctionService();
    }

    public WpfFrontendBuilder AddCustomControl<TControl, TValue>(Func<Argument, TControl> factory)
        where TControl : Control, IArgumentControl
    {
        controlFactory.AddCustomControl<TControl, TValue>(factory);
        return this;
    }

    public WpfFrontendBuilder Title(string title)
    {
        this.title = title;
        return this;
    }

    public WpfFrontendBuilder Icon(ImageSource icon)
    {
        this.icon = icon;
        return this;
    }

    public void RunWpfApplication()
    {
        var mainWindow = new MainWindow(frontend, globalFunctionService, controlFactory);
        mainWindow.Title = title;
        mainWindow.Icon = icon;
        mainWindow.ShowDialog();
    }
}
