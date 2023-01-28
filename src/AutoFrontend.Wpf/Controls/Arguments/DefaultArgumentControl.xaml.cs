using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Text.Json;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultArgumentControl : UserControl, IArgumentControl
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

    private Argument? argument;
    private ServiceLocator? serviceLocator;

    public DefaultArgumentControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument, bool isReadOnly)
    {
        this.argument = argument;
        this.serviceLocator = serviceLocator;

        label.Header = argument.Name;

        if (isReadOnly)
        {
            textBox.IsReadOnly = true;
            contextMenu.IsEnabled = false;
        }
        else
        {
            SetRandomData();
        }
    }

    public void SetArgumentValue(object? value)
    {
        textBox.Text = JsonSerializer.Serialize(value, JsonSerializerOptions);
    }

    public object? GetArgumentValue()
    {
        if (argument == null)
        {
            throw new Exception($"Field {nameof(argument)} is required");
        }
        return JsonSerializer.Deserialize(textBox.Text, argument.AwaitResultType);
    }

    private void SetRandomData()
    {
        if (argument == null || serviceLocator == null)
        {
            throw new Exception($"Fields {nameof(argument)}, {nameof(serviceLocator)} are required");
        }
        var fixture = serviceLocator.Fixture.Create(argument.AwaitResultType);
        textBox.Text = JsonSerializer.Serialize(fixture, JsonSerializerOptions);
    }

    private void GenerateRandomValue_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        SetRandomData();
    }
}
