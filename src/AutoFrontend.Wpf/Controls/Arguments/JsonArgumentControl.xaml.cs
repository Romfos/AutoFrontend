using AutoFrontend.Models;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using TestFixture;

namespace AutoFrontend.Wpf.Controls.Arguments;

public partial class JsonArgumentControl : UserControl, IArgumentControl
{
    private static readonly Fixture fixture = new Fixture();

    private readonly Type valueType;

    private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    public JsonArgumentControl(ArgumentModel argument)
    {
        InitializeComponent();

        valueType = argument.Type;

        label.Content = argument.Name;

        try
        {
            textBox.Text = JsonSerializer.Serialize(fixture.Create(argument.Type), jsonSerializerOptions);
        }
        catch (Exception ex)
        {
            exception.Content = ex.Message;
            exception.Visibility = Visibility.Visible;
        }
    }

    public object? GetValue()
    {
        try
        {
            exception.Visibility = Visibility.Collapsed;
            return JsonSerializer.Deserialize(textBox.Text, valueType, jsonSerializerOptions);
        }
        catch (Exception ex)
        {
            exception.Content = ex.Message;
            exception.Visibility = Visibility.Visible;
            throw;
        }
    }

    private void TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            GetValue();
        }
        catch
        {
        }
    }
}
