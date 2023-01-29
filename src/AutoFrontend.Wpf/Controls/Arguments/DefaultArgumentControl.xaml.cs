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

    public DefaultArgumentControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument, bool isReadOnly)
    {
        this.argument = argument;

        if (isReadOnly)
        {
            textBox.IsReadOnly = true;
            generateRandomValue.IsEnabled = false;
        }
        else
        {
            generateRandomValue.Click += (_, _) => SetRandomData(serviceLocator, argument);
            SetRandomData(serviceLocator, argument);
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

    private void SetRandomData(ServiceLocator serviceLocator, Argument argument)
    {
        var fixture = serviceLocator.Fixture.Create(argument.AwaitResultType);
        textBox.Text = JsonSerializer.Serialize(fixture, JsonSerializerOptions);
    }
}
