using System.Collections.Generic;
using System.Reflection;

namespace AutoFrontend.Models;

public sealed class OperationModel
{
    public string Name { get; }
    public object? Target { get; }
    public MethodInfo MethodInfo { get; }

    public List<ArgumentModel> Arguments { get; } = new();
    public ResultModel Result { get; }

    public OperationModel(
        string name,
        object? target,
        MethodInfo methodInfo,
        ResultModel result)
    {
        Name = name;
        Target = target;
        MethodInfo = methodInfo;
        Result = result;
    }
}
