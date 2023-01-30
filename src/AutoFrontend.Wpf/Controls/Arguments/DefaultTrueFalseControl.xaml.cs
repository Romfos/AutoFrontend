using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultTrueFalseControl : UserControl, IArgumentControl
{
    public DefaultTrueFalseControl(Argument argument)
    {
        InitializeComponent();

        label.Content = argument.Name;
        stackPanel.IsEnabled = !argument.IsResult;
    }

    public object? ArgumentValue
    {
        get => trueButton.IsChecked == true;
        set
        {
            if (value is true)
            {
                trueButton.IsChecked = true;
            }
            else
            {
                falseButton.IsChecked = true;
            }
        }
    }

    public bool IsValid { get; } = true;
}
