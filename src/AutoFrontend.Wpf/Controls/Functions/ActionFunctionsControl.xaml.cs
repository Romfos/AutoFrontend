using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Controls.Functions;

public partial class ActionFunctionsControl : UserControl
{
    public ActionFunctionsControl()
    {
        InitializeComponent();
    }

    public void Configure(ServiceLocator serviceLocator, List<Function> functions)
    {
        grid.Rows = (functions.Count / 5) + 1;

        foreach (var function in functions)
        {
            var actionbutton = new Button
            {
                Content = function.Name,
                Padding = new Thickness(5)
            };
            actionbutton.Click += (s, e) => Execute(serviceLocator, function);
            grid.Children.Add(actionbutton);
        }
    }

    private async void Execute(ServiceLocator serviceLocator, Function function)
    {
        grid.IsEnabled = false;
        exceptionGroup.Visibility = Visibility.Collapsed;
        progressBar.Visibility = Visibility.Visible;

        try
        {
            var functionTask = serviceLocator.FunctionExecutor.ExecuteFunctionAsync(function, null);
            await Task.WhenAll(Task.Delay(300), functionTask);
        }
        catch (Exception exception)
        {
            exceptionGroup.Header = function.Name;
            exceptionGroup.Visibility = Visibility.Visible;
            exceptionTextBox.Text = exception.ToString();
            exceptionTextBox.Visibility = Visibility.Visible;
        }

        progressBar.Visibility = Visibility.Collapsed;
        grid.IsEnabled = true;
    }
}
