using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Editors;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class ArgumentControl : UserControl
{
    private readonly IEditorControl editorControl;

    public ArgumentControl(Argument argument, EditorControlFactory editorControlFactory)
    {
        InitializeComponent();

        label.Content = argument.Name;

        editorControl = editorControlFactory.Create(argument.Type);

        editorStackPanel.Children.Add((Control)editorControl);
    }

    public object? GetValue()
    {
        return editorControl.GetValue();
    }
}
