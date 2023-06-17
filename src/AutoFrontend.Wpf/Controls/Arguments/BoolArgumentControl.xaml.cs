using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class BoolArgumentControl : UserControl, IArgumentControl
{
    public BoolArgumentControl(ArgumentModel argument)
    {
        InitializeComponent();

        checkbox.Content = argument.Name;
    }

    public object? GetValue()
    {
        return checkbox.IsChecked;
    }
}
