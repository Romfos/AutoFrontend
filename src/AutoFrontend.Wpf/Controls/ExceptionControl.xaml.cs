using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class ExceptionControl : UserControl
{
    public ExceptionControl()
    {
        InitializeComponent();

        Reset();
    }

    public void Reset()
    {
        expander.Visibility = Visibility.Collapsed;
    }

    public void SetException(Exception exception)
    {
        expander.Visibility = Visibility.Visible;
        expander.Header = exception.Message;
        exceptionDetailsTextBox.Text = exception.ToString();
    }
}
