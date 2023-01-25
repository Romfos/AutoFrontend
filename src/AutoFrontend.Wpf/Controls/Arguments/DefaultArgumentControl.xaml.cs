using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Text.Json;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultArgumentControl : UserControl, IArgumentControl
{
    private Argument? argument;
    private ServiceLocator? serviceLocator;

    public DefaultArgumentControl()
    {
        InitializeComponent();
    }

    public void Setup(Argument argument, ServiceLocator serviceLocator)
    {
        this.argument = argument;
        this.serviceLocator = serviceLocator;

        label.Header = argument.Name;
        Reset();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Reset();
    }

    private void Reset()
    {
        if (argument == null || serviceLocator == null)
        {
            return;
        }
        var fixture = serviceLocator.Fixture.Create(argument.ValueType);
        textBox.Text = JsonSerializer.Serialize(fixture, new JsonSerializerOptions() { WriteIndented = true });
    }
}
