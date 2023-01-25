using AutoFrontend.Models;
using AutoFrontend.Wpf.Services;

namespace AutoFrontend.Wpf.Controls.Arguments;

public interface IArgumentControl
{
    void Setup(Argument argument, ServiceLocator servcieLocator);
}
