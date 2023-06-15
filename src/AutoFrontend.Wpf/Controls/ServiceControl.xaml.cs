using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoFrontend.Wpf.Controls;

public partial class ServiceControl : UserControl
{
    public ServiceControl(Service service, EditorControlFactory editorControlFactory)
    {
        InitializeComponent();

        foreach (var operation in service.Operations)
        {
            var border = new Border
            {
                Background = operationsStackPanel.Children.Count % 2 == 0 ? Brushes.White : Brushes.WhiteSmoke,
                Child = new OperationControl(operation, editorControlFactory)
            };

            operationsStackPanel.Children.Add(border);
        }
    }
}
