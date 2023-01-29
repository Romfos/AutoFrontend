using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class CustomStringControl : UserControl, IArgumentControl
{
    public Func<string, object?>? ParseFunction { get; set; }

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
    }

    public object? GetArgumentValue()
    {
        var result = ParseFunction?.Invoke(textBox.Text);
        if (result == null)
        {
            throw new Exception($"Unable to parse {argument?.AwaitResultType.FullName}");
        }
        return result;
    }

    public void SetArgumentValue(object? value)
    {
        textBox.Text = value?.ToString();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (ParseFunction?.Invoke(textBox.Text) != null)
        {
            errorLabel.Visibility = Visibility.Collapsed;
        }
        else
        {
            errorLabel.Visibility = Visibility.Visible;
        }
    }
}
