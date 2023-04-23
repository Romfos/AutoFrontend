using System.Collections.Generic;
using System.Reflection;

namespace AutoFrontend.Models;

public sealed class Operation
{
    public string Name { get; }
    public object? Target { get; }
    public MethodInfo MethodInfo { get; }

    public List<Argument> Arguments { get; } = new();
    public OperationResult Result { get; }

    public Operation(
        string name,
        object? target,
        MethodInfo methodInfo,
        OperationResult result)
    {
        Name = name;
        Target = target;
        MethodInfo = methodInfo;
        Result = result;
    }
}
