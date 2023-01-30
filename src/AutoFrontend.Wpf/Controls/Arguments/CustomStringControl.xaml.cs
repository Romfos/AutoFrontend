using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class CustomStringControl : UserControl, IArgumentControl
{
    public Func<string, object?>? TryParseDelegate { get; set; }

    private Argument? argument;

    public CustomStringControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument)
    {
        this.argument = argument;

        label.Content = argument.Name;
        errorLabel.Content = $"Relevant {argument.ArgumentType.FullName} is expected";

        textBox.IsReadOnly = argument.IsResult;
        textBox.TextChanged += TextBox_TextChanged;
        SetRandomData(serviceLocator, argument);
    }

    public object? ArgumentValue
    {
        get => TryParseDelegate?.Invoke(textBox.Text);
        set => textBox.Text = value?.ToString();
    }

    public bool IsValid => TryParseDelegate?.Invoke(textBox.Text) != null;

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (TryParseDelegate?.Invoke(textBox.Text) != null)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }
        else
        {
            errorLabel.Visibility = Visibility.Visible;
        }
    }

    private void SetRandomData(ServiceLocator serviceLocator, Argument argument)
    {
        try
        {
            var fixture = serviceLocator.Fixture.Create(argument.ArgumentType);
            textBox.Text = fixture.ToString();
        }
        catch (Exception)
        {
            textBox.Text = "Unable to generate random value";
        }
    }
}
