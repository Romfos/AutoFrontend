using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class StringArgumentControl : UserControl, IArgumentControl
{
    public StringArgumentControl(ArgumentModel argument, string defaultValue)
    {
        InitializeComponent();

        label.Content = argument.Name;
        textBox.Text = defaultValue;
    }

    public object? GetValue()
    {
        return textBox.Text;
    }
}
