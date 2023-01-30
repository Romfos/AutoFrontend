using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class DefaultStringControl : UserControl, IArgumentControl
{
    public DefaultStringControl(Argument argument)
    {
        InitializeComponent();

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
