using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;

namespace AutoFrontend.Wpf.Controls.Arguments;

public interface IArgumentControl
{
    void Configure(ServiceLocator serviceLocator, Argument argument, bool isReadOnly);

    object? ArgumentValue { get; set; }
}
