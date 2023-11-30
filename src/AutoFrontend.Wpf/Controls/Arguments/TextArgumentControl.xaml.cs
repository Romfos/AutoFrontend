using AutoFrontend.Models;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class TextArgumentControl : UserControl, IArgumentControl
{
    private readonly ArgumentModel argument;
    private readonly Func<string, object?> converter;

    public TextArgumentControl(ArgumentModel argument, Func<string, object?> converter, string defaultValue)
    {
        InitializeComponent();

        this.argument = argument;
        this.converter = converter;

        label.Content = argument.Name;
        textBox.Text = defaultValue;
    }

    public object? GetValue()
    {
        try
        {
            exception.Visibility = Visibility.Collapsed;
            return converter(textBox.Text);
        }
        catch
        {
            exception.Content = $"Unable to parse {argument.Type.FullName}";
            exception.Visibility = Visibility.Visible;
            throw;
        }
    }

    private void TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            GetValue();
        }
        catch
        {
        }
    }
}
