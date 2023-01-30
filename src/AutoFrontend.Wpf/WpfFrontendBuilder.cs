using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using AutoFrontend.Wpf.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf;

public sealed class WpfFrontendBuilder
{
    private readonly Frontend frontend;
    private readonly ServiceLocator serviceLocator = new();

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

    public void RunWpfApplication()
    {
        var mainWindow = new MainWindow();
        mainWindow.Setup(frontend, serviceLocator);
        mainWindow.ShowDialog();
    }
}
