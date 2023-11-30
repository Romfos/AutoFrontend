using AutoFrontend.Models;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class EnumArgumentControl : UserControl, IArgumentControl
{
    private readonly ArgumentModel argument;

    public EnumArgumentControl(ArgumentModel argument)
    {
        InitializeComponent();

        this.argument = argument;

        foreach (var name in Enum.GetNames(argument.Type))
        {
            comboBox.Items.Add(name);
        }

        label.Content = argument.Name;
    }

    public object? GetValue()
    {
        return Enum.Parse(argument.Type, comboBox.Text);
    }
}
