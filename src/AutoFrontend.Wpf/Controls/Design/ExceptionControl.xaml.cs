using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Design;

public partial class ExceptionControl : UserControl
{
    public ExceptionControl()
    {
        InitializeComponent();
    }

    public void Reset()
    {
        Visibility = Visibility.Collapsed;
    }

    public void Exception(string? header, Exception exception)
    {
        groupBox.Header = header;
        textBox.Text = exception.ToString();
        Visibility = Visibility.Visible;
    }
}
