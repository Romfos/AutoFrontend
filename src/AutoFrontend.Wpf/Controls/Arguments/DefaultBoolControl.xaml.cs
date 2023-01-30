using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultBoolControl : UserControl, IArgumentControl
{
    public DefaultBoolControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Argument argument)
    {
        checkBox.Content = argument.Name;
        checkBox.IsEnabled = !argument.IsResult;
    }

    public object? ArgumentValue
    {
        get => checkBox.IsChecked == true;
        set => checkBox.IsChecked = (bool?)value == true;
    }

    public bool IsValid { get; } = true;
}
