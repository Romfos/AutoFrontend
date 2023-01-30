using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Text.Json;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class JsonStringControl : UserControl, IArgumentControl
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

    private Argument? argument;

    public JsonStringControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument)
    {
        if (argument.Name != null)
        {
            label.Content = argument.Name;
        }

        this.argument = argument;

        if (argument.IsResult)
        {
            textBox.IsReadOnly = true;
            generateRandomValue.IsEnabled = false;
        }
        else
        {
            generateRandomValue.Click += (_, _) => GenerateRandomData(serviceLocator, argument);
            GenerateRandomData(serviceLocator, argument);
            textBox.TextChanged += TextBox_TextChanged;
        }
    }

    public object? ArgumentValue
    {
        get
        {
            if (argument == null)
            {
                throw new Exception($"Field {nameof(argument)} is required");
            }
            return JsonSerializer.Deserialize(textBox.Text, argument.ArgumentType);
        }
        set => textBox.Text = JsonSerializer.Serialize(value, JsonSerializerOptions);
    }

    public bool IsValid => UpdateValidationState();

    private void GenerateRandomData(ServiceLocator serviceLocator, Argument argument)
    {
        try
        {
            var fixture = serviceLocator.Fixture.Create(argument.ArgumentType);
            textBox.Text = JsonSerializer.Serialize(fixture, JsonSerializerOptions);
        }
        catch (Exception)
        {
            textBox.Text = "Unable to generate random value";
        }
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateValidationState();
    }

    private bool UpdateValidationState()
    {
        if (argument == null)
        {
            return false;
        }
        try
        {
            JsonSerializer.Deserialize(textBox.Text, argument.ArgumentType);
            validationControl.Reset();
            return true;
        }
        catch (Exception exception)
        {
            validationControl.Validation(argument.ArgumentType.FullName, exception.Message);
            return false;
        }
    }
}
