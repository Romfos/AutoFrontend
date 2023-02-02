using System.Collections.Generic;
using System.Reflection;

namespace AutoFrontend.Models;

public sealed class Function
{
    public object? Target { get; }
    public MethodInfo MethodInfo { get; }
    public string Name { get; }
    public Definition Result { get; }
    public bool IsAsync { get; }

    public List<Argument> Arguments { get; } = new();

    public Function(object? target, MethodInfo methodInfo, string name, Definition result, bool isAsync)
    {
        Target = target;
        MethodInfo = methodInfo;
        Name = name;
        Result = result;
        IsAsync = isAsync;
    }
}
