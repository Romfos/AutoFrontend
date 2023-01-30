using AutoFrontend.Models;
using System;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class EnumControl : UserControl, IArgumentControl
{
    private readonly Argument argument;

    public EnumControl(Argument argument)
    {
        InitializeComponent();

        label.Content = argument.Name;
        comboBox.IsReadOnly = argument.IsResult;

        foreach (var name in Enum.GetNames(argument.ArgumentType))
        {
            comboBox.Items.Add(name);
        }

        this.argument = argument;
    }

    public object? ArgumentValue
    {
        get => Enum.Parse(argument.ArgumentType, (string)comboBox.SelectedItem);
        set => comboBox.SelectedItem = value?.ToString();
    }

    public bool IsValid { get; } = true;
}
