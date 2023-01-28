using System.Collections.Generic;
using System.Reflection;

namespace AutoFrontend.Models;

public sealed class Function
{
    public object? Target { get; }
    public MethodInfo MethodInfo { get; }
    public string Name { get; }

    public List<Argument> Arguments { get; } = new();
    public Argument Result { get; set; }

    public Function(object? target, MethodInfo methodInfo)
    {
        Target = target;
        MethodInfo = methodInfo;
        Name = methodInfo.Name;

        Result = new Argument(null, typeof(void), false, false);
    }
}
