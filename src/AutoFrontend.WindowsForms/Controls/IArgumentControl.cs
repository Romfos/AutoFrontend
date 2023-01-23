using AutoFrontend.Models;

namespace AutoFrontend.WindowsForms.Controls;

public interface IArgumentControl
{
    Argument? Argument { get; }

    void Setup(Argument argument);
}
