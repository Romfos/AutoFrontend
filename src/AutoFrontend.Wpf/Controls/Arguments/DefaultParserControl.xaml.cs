using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultParserControl : UserControl, IArgumentControl
{
    public Func<string, object?>? TryParseFunction { get; set; }

    private Argument? argument;

    public DefaultParserControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument, bool isReadOnly)
    {
        this.argument = argument;

        label.Content = $"Relevant {argument.AwaitResultType.FullName} is expected";

        textBox.IsReadOnly = isReadOnly;
        textBox.TextChanged += TextBox_TextChanged;
    }

    public object? GetArgumentValue()
    {
        var result = TryParseFunction?.Invoke(textBox.Text);
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
        if (TryParseFunction?.Invoke(textBox.Text) != null)
        {
            label.Visibility = Visibility.Collapsed;
        }
        else
        {
            label.Visibility = Visibility.Visible;
        }
    }
}
