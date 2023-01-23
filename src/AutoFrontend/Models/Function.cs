using System.Collections.Generic;
using System.Reflection;

namespace AutoFrontend.Models;

public sealed class Function
{
    public object? Target { get; }
    public MethodInfo MethodInfo { get; }
    public string Name { get; }

    public List<Argument> Input { get; } = new();
    public List<Argument> Output { get; } = new();

    public Function(object? target, MethodInfo methodInfo)
    {
        Target = target;
        MethodInfo = methodInfo;
        Name = methodInfo.Name;
    }
}
