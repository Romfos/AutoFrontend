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

    public void Exception(string functionName, Exception exception)
    {
        groupBox.Header = functionName;
        textBox.Text = exception.ToString();
        Visibility = Visibility.Visible;
    }
}
