using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using AutoFrontend.Wpf.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoFrontend.Wpf;

public sealed class WpfFrontendBuilder
{
    private readonly Frontend frontend;
    private readonly ServiceLocator serviceLocator = new();

    private string title = "AutoFrontend";
    private ImageSource? icon;

    public WpfFrontendBuilder(Frontend frontend)
    {
        this.frontend = frontend;
    }

    public WpfFrontendBuilder AddCustomControl<TControl, TValue>()
        where TControl : Control, IArgumentControl, new()
    {
        serviceLocator.ControlFactory.AddCustomControl<TControl, TValue>();
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
        var mainWindow = new MainWindow();
        mainWindow.Title = title;
        mainWindow.Setup(frontend, serviceLocator);
        mainWindow.Icon = icon;
        mainWindow.ShowDialog();
    }
}
