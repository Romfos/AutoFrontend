using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;

namespace AutoFrontend.Wpf.Controls.Arguments;

public interface IArgumentControl
{
    void Configure(ServiceLocator serviceLocator, Argument argument);

    object? ArgumentValue { get; set; }

    bool IsValid { get; }
}
