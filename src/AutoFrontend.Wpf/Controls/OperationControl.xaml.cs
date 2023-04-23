using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls;

public partial class OperationControl : UserControl
{
    private readonly Operation operation;
    private readonly List<ArgumentControl> argumentControls;
    private readonly OperationResultControl operationResultControl;

    public OperationControl(Operation operation, EditorControlFactory editorControlFactory)
    {
        InitializeComponent();

        argumentControls = new(operation.Arguments.Count);

        foreach (var argument in operation.Arguments)
        {
            var argumentControl = new ArgumentControl(argument, editorControlFactory);
            argumentControls.Add(argumentControl);
            argumentStackPanel.Children.Add(argumentControl);
        }

        executeButton.Content = operation.Name;

        operationResultControl = new OperationResultControl(operation.Result, editorControlFactory);
        resultStackPanel.Children.Add(operationResultControl);
        this.operation = operation;
    }

    private async void Execute(object sender, RoutedEventArgs e)
    {
        try
        {
            operationResultControl.Reset();
            progressBar.Visibility = Visibility.Visible;

            var arguments = argumentControls.Select(x => x.GetValue()).ToArray();

            var operationTask = ExecuteOperationAsync(arguments);

            await Task.WhenAll(operationTask, Task.Delay(300));

            operationResultControl.SetValue(operationTask.Result);
        }
        catch (Exception exception)
        {
            operationResultControl.SetException(exception);
        }
        finally
        {
            progressBar.Visibility = Visibility.Collapsed;
        }
    }

    private async Task<object?> ExecuteOperationAsync(object?[] arguments)
    {
        if (operation.Result.IsAsync)
        {
            if (operation.Result.Type == typeof(void))
            {
                await (dynamic?)operation.MethodInfo.Invoke(operation.Target, arguments);
                return null;
            }
            else
            {
                return await (dynamic?)operation.MethodInfo.Invoke(operation.Target, arguments);
            }
        }
        else
        {
            if (operation.Result.Type == typeof(void))
            {
                await Task.Run(() => operation.MethodInfo.Invoke(operation.Target, arguments));
                return null;
            }
            else
            {
                return await Task.Run(() => operation.MethodInfo.Invoke(operation.Target, arguments));
            }
        }
    }
}
