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

    public void Configure(ServiceLocator serviceLocator, Argument argument)
    {
        label.Content = argument.Name;
        textBox.IsReadOnly = argument.IsResult;
    }

    public object? ArgumentValue
    {
        get => textBox.Text;
        set => textBox.Text = value as string;
    }

    public bool IsValid { get; } = true;
}
