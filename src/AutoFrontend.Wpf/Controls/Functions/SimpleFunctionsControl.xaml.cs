using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Functions;

public partial class SimpleFunctionsControl : UserControl
{
    private readonly GlobalFunctionService globalFunctionService;

    public SimpleFunctionsControl(GlobalFunctionService globalFunctionService, List<Function> functions)
    {
        InitializeComponent();

        this.globalFunctionService = globalFunctionService;

        grid.Rows = (functions.Count / 5) + 1;

        foreach (var function in functions)
        {
            var actionbutton = new Button
            {
                Content = function.Name,
                Padding = new Thickness(5)
            };
            actionbutton.Click += (s, e) => Execute(function);
            grid.Children.Add(actionbutton);
        }
    }


    private async void Execute(Function function)
    {
        grid.IsEnabled = false;
        validationControl.Reset();
        progressBar.Visibility = Visibility.Visible;

        try
        {
            var functionTask = globalFunctionService.ExecuteWithNotificationAsync(function, null);
            await Task.WhenAll(Task.Delay(300), functionTask);
        }
        catch (Exception exception)
        {
            validationControl.Validation(function.Name, exception);
        }

        progressBar.Visibility = Visibility.Collapsed;
        grid.IsEnabled = true;
    }
}
