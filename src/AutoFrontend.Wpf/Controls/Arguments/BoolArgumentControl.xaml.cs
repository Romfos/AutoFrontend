using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class BoolArgumentControl : UserControl, IArgumentControl
{
    public BoolArgumentControl(Argument argument)
    {
        InitializeComponent();

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
