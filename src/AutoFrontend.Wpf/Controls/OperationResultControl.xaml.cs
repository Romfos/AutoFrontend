using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Editors;
using AutoFrontend.Wpf.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class OperationResultControl : UserControl
{
    private readonly IEditorControl editorControl;

    public OperationResultControl(OperationResult operationResult, EditorControlFactory editorControlFactory)
    {
        InitializeComponent();

        editorControl = editorControlFactory.Create(operationResult.Type);
        editorStackPanel.Children.Add((Control)editorControl);
        editorControl.MakeReadOnly();

        Reset();
    }

    public void Reset()
    {
        exceptionControl.Reset();
        editorStackPanel.Visibility = Visibility.Collapsed;
    }

    public void SetValue(object? value)
    {
        editorControl.SetValue(value);
        editorStackPanel.Visibility = Visibility.Visible;
    }

    public void SetException(Exception exception)
    {
        exceptionControl.SetException(exception);
    }
}
