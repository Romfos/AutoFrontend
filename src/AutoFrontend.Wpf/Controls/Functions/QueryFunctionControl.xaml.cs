using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Functions;

public partial class QueryFunctionControl : UserControl
{
    public QueryFunctionControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, Function function)
    {
        expander.Header = function.Name;

        expander.Expanded += (_, _) => Execute(serviceLocator, function);
        executeButton.Click += (_, _) => Execute(serviceLocator, function);

        var resultControl = CreateArgumentControl(function.Result, serviceLocator, true);
        resultStack.Children.Add(new GroupBox
        {
            Header = function.Name,
            Content = resultControl,
        });

        serviceLocator.FunctionExecutor.OnFunctionExecuted += () =>
        {
            if (autoRefresh.IsChecked == true && expander.IsExpanded)
            {
                Execute(serviceLocator, function);
            }
        };
    }

    private Control CreateArgumentControl(Argument argument, ServiceLocator servcieLocator, bool IsReadOnly)
    {
        var control = servcieLocator.ControlFactory.Create(argument.AwaitResultType);
        if (control is not IArgumentControl argumentControl)
        {
            throw new Exception("Unable to resolve control");
        }
        argumentControl.Configure(servcieLocator, argument, IsReadOnly);
        return control;
    }

    private async void Execute(ServiceLocator serviceLocator, Function function)
    {
        executeButton.IsEnabled = false;
        progressBar.Visibility = Visibility.Visible;
        resultStack.Visibility = Visibility.Visible;
        exceptionControl.Reset();

        try
        {
            var result = await serviceLocator.FunctionExecutor.ExecuteQueryAsync(function, null);

            if (function.Result.AwaitResultType != typeof(void))
            {
                var resultArgumentControl = resultStack.Children
                    .Cast<GroupBox>()
                    .Select(x => x.Content)
                    .Cast<IArgumentControl>()
                    .Single();

                resultArgumentControl.SetArgumentValue(result);
            }
        }
        catch (Exception exception)
        {
            exceptionControl.Exception(exception);
            resultStack.Visibility = Visibility.Collapsed;
        }

        progressBar.Visibility = Visibility.Collapsed;
        executeButton.IsEnabled = true;
    }
}
