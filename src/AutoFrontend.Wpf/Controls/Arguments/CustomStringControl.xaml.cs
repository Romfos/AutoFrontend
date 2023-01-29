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

    public void Configure(ServiceLocator serviceLocator, Argument argument, bool isReadOnly)
    {
        this.argument = argument;

        label.Content = argument.Name;
        errorLabel.Content = $"Relevant {argument.AwaitResultType.FullName} is expected";

        textBox.IsReadOnly = isReadOnly;
        textBox.TextChanged += TextBox_TextChanged;
        SetRandomData(serviceLocator, argument);
    }

    public object? ArgumentValue
    {
        get
        {
            var result = TryParseDelegate?.Invoke(textBox.Text);
            if (result == null)
            {
                throw new Exception($"Unable to parse {argument?.AwaitResultType.FullName}");
            }
            return result;
        }
        set => textBox.Text = value?.ToString();
    }

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
            var fixture = serviceLocator.Fixture.Create(argument.AwaitResultType);
            textBox.Text = fixture.ToString();
        }
        catch (Exception)
        {
            textBox.Text = "Unable to generate random value";
        }
    }
}
