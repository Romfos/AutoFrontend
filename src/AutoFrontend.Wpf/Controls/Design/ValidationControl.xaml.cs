using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Design;

public partial class ValidationControl : UserControl
{
    public ValidationControl()
    {
        InitializeComponent();
    }

    public void Reset()
    {
        Visibility = Visibility.Collapsed;
    }

    public void Validation(string? header, Exception exception)
    {
        groupBox.Header = header;
        textBox.Text = exception.ToString();
        Visibility = Visibility.Visible;
    }

    public void Validation(string? header, string error)
    {
        groupBox.Header = header;
        textBox.Text = error;
        Visibility = Visibility.Visible;
    }
}
