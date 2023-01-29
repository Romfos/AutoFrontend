using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultIntegerControl : UserControl, IArgumentControl
{
    public DefaultIntegerControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument, bool isReadOnly)
    {
        textBox.IsReadOnly = isReadOnly;
        textBox.TextChanged += TextBox_TextChanged;
    }

    public object? GetArgumentValue()
    {
        if (!int.TryParse(textBox.Text, out var interger))
        {
            throw new Exception("Unable to parse number");
        }
        return interger;
    }

    public void SetArgumentValue(object? value)
    {
        textBox.Text = value?.ToString();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(textBox.Text, out _))
        {
            label.Visibility = Visibility.Collapsed;
        }
        else
        {
            label.Visibility = Visibility.Visible;
        }
    }
}