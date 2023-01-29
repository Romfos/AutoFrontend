using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultStringControl : UserControl, IArgumentControl
{
    public DefaultStringControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument, bool isReadOnly)
    {
        label.Content = argument.Name;
        textBox.IsReadOnly = isReadOnly;
    }

    public object? GetArgumentValue()
    {
        return textBox.Text;
    }

    public void SetArgumentValue(object? value)
    {
        textBox.Text = value as string;
    }
}
