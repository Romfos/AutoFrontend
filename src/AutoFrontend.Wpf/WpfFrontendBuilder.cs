using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls;
using AutoFrontend.Wpf.Controls.Editors;
using AutoFrontend.Wpf.Services;
using System;
using System.Windows.Media;

namespace AutoFrontend.Wpf;

public sealed class WpfFrontendBuilder
{
    private readonly ApplicationFrontend applicationFrontend;
    private readonly EditorControlFactory controlFactory = new();

    private string title = "AutoFrontend";
    private ImageSource? icon;

    public WpfFrontendBuilder(ApplicationFrontend applicationFrontend)
    {
        this.applicationFrontend = applicationFrontend;
    }

    public WpfFrontendBuilder RegisterCustomEditorFactory(Func<Type, IEditorControl?> factory)
    {
        controlFactory.Register(factory);
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
        var mainWindow = new AutoFrontendWindow(applicationFrontend, controlFactory);
        mainWindow.Title = title;
        mainWindow.Icon = icon;
        mainWindow.ShowDialog();
    }
}
