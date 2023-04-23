using System;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Editors;

public partial class TextEditorControl : UserControl, IEditorControl
{
    private readonly Func<object?, string?> setValue;
    private readonly Func<string?, object?> getValue;

    public TextEditorControl(
        Func<object?, string?> setValue,
        Func<string?, object?> getValue,
        string defaultValue)
    {
        InitializeComponent();

        this.setValue = setValue;
        this.getValue = getValue;

        textBox.Text = defaultValue;
    }

    public object? GetValue()
    {
        return getValue(textBox.Text);
    }

    public void MakeReadOnly()
    {
        textBox.IsReadOnly = true;
    }

    public void SetValue(object? value)
    {
        textBox.Text = setValue(value);
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            exceptionControl.Reset();
            GetValue();
        }
        catch (Exception exception)
        {
            exceptionControl.SetException(exception);
        }
    }
}
