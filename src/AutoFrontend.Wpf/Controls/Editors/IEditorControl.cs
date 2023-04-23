namespace AutoFrontend.Wpf.Controls.Editors;

public interface IEditorControl
{
    object? GetValue();

    void SetValue(object? value);

    void MakeReadOnly();
}
