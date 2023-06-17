using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Controls.Results;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Operations;

public partial class DefaultOperationControl : UserControl
{
    private readonly OperationModel operation;

    public DefaultOperationControl(ControlFactory controlFactory, OperationModel operation)
    {
        InitializeComponent();

        this.operation = operation;

        button.Content = operation.Name;

        foreach (var argument in operation.Arguments)
        {
            arguments.Children.Add(controlFactory.Resolve<Control>(argument));
        }

        results.Children.Add(controlFactory.Resolve<Control>(operation.Result));
    }

    private async void Execute(object sender, RoutedEventArgs e)
    {
        try
        {
            exception.Visibility = Visibility.Collapsed;
            results.Visibility = Visibility.Collapsed;
            progress.Visibility = Visibility.Visible;

            var parameters = arguments.Children.OfType<IArgumentControl>()
                .Select(x => x.GetValue())
                .ToArray();

            var task = ExectueAsync(parameters);

            await Task.WhenAll(task, Task.Delay(200));

            results.Children.OfType<IResultControl>().Single().SetValue(task.Result);
            results.Visibility = Visibility.Visible;
        }
        catch (Exception ex)
        {
            exception.Text = ex.ToString();
            exception.Visibility = Visibility.Visible;
        }
        finally
        {
            progress.Visibility = Visibility.Collapsed;
        }
    }

    private async Task<object?> ExectueAsync(object?[]? parameters)
    {
        if (operation.Result.IsAsync)
        {
            if (operation.Result.Type == typeof(void))
            {
                await (dynamic?)operation.MethodInfo.Invoke(operation.Target, parameters);
                return null;
            }
            else
            {
                return await (dynamic?)operation.MethodInfo.Invoke(operation.Target, parameters);
            }
        }
        else
        {
            return await Task.Factory.StartNew(() => operation.MethodInfo.Invoke(operation.Target, parameters));
        }
    }
}
