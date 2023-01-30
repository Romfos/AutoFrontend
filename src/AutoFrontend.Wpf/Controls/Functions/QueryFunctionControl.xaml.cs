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
    private readonly Function function;
    private readonly GlobalFunctionService globalFunctionService;

    public QueryFunctionControl(
        Function function,
        GlobalFunctionService globalFunctionService,
        ControlFactory controlFactory)
    {
        InitializeComponent();

        this.function = function;
        this.globalFunctionService = globalFunctionService;

        expander.Header = function.Name;

        var argumentControl = controlFactory.Create(function.Result);
        resultStack.Children.Add(argumentControl);

        expander.Expanded += (_, _) => Execute();
        executeButton.Click += (_, _) => Execute();

        globalFunctionService.OnFunctionExecuted += () =>
        {
            if (autoRefresh.IsChecked == true && expander.IsExpanded)
            {
                Execute();
            }
        };
    }

    private async void Execute()
    {
        executeButton.IsEnabled = false;
        progressBar.Visibility = Visibility.Visible;
        resultStack.Visibility = Visibility.Visible;
        validationControl.Reset();

        try
        {
            var result = await globalFunctionService.ExecuteAsync(function, null);

            if (function.Result.ArgumentType != typeof(void))
            {
                var resultArgumentControl = resultStack.Children
                    .Cast<IArgumentControl>()
                    .Single();

                resultArgumentControl.ArgumentValue = result;
            }
        }
        catch (Exception exception)
        {
            validationControl.Validation(function.Name, exception);
            resultStack.Visibility = Visibility.Collapsed;
        }

        progressBar.Visibility = Visibility.Collapsed;
        executeButton.IsEnabled = true;
    }
}
