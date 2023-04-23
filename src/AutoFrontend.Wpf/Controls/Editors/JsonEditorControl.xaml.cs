using System;
using System.Text.Json;
using System.Windows.Controls;
using TestFixture;

namespace AutoFrontend.Wpf.Controls.Editors;

public partial class JsonEditorControl : IEditorControl
{
    private static readonly Fixture fixture = new();
    private static readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    private readonly Type type;

    public JsonEditorControl(Type type)
    {
        InitializeComponent();

        this.type = type;

        GenerateRandomValue();
    }

    public object? GetValue()
    {
        return JsonSerializer.Deserialize(textBox.Text, type, jsonSerializerOptions);
    }

    public void SetValue(object? value)
    {
        textBox.Text = JsonSerializer.Serialize(value, type, jsonSerializerOptions);
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

    private void GenerateRandomValue()
    {
        try
        {
            SetValue(fixture.Create(type));
        }
        catch (Exception exception)
        {
            exceptionControl.SetException(exception);
        }
    }

    public void MakeReadOnly()
    {
        textBox.IsReadOnly = true;
    }
}
