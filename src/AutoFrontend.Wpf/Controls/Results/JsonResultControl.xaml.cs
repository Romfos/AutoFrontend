using AutoFrontend.Models;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Results;

public partial class JsonResultControl : UserControl, IResultControl
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    public JsonResultControl(ResultModel result)
    {
        InitializeComponent();
    }

    public void SetValue(object? value)
    {
        try
        {
            exception.Visibility = Visibility.Hidden;
            textBox.Text = JsonSerializer.Serialize(value, jsonSerializerOptions);
        }
        catch (Exception ex)
        {
            exception.Content = ex.Message;
            exception.Visibility = Visibility.Visible;
        }
    }
}
