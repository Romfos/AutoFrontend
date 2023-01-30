using AutoFrontend.Models;
using System;
using System.Text.Json;
using System.Windows.Controls;
using TestFixture;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class JsonStringControl : UserControl, IArgumentControl
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

    private readonly Argument argument;
    private readonly Fixture fixture;

    public JsonStringControl(Argument argument, Fixture fixture)
    {
        InitializeComponent();

        this.argument = argument;
        this.fixture = fixture;

        if (argument.Name != null)
        {
            label.Content = argument.Name;
        }
        if (argument.IsResult)
        {
            textBox.IsReadOnly = true;
            generateRandomValue.IsEnabled = false;
        }
        else
        {
            generateRandomValue.Click += (_, _) => GenerateRandomValue();
            textBox.TextChanged += TextBox_TextChanged;
            GenerateRandomValue();
        }
    }

    public object? ArgumentValue
    {
        get => JsonSerializer.Deserialize(textBox.Text, argument.ArgumentType);
        set => textBox.Text = JsonSerializer.Serialize(value, JsonSerializerOptions);
    }

    public bool IsValid => UpdateValidationState();

    private void GenerateRandomValue()
    {
        try
        {
            var value = fixture.Create(argument.ArgumentType);
            textBox.Text = JsonSerializer.Serialize(value, JsonSerializerOptions);
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
